using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

public class PlayerUIInterface : MonoBehaviour
{
    private List<int> PlayersInteract = new List<int> {-1, -1};
    private List<GameObject> PlayerUIs;
    private TowerDataSet Towers;
    public Button TowerButton;

    private void Start()
    {
        GameObject PlayerOneUI = GameObject.Find("Player 1 Panel");
        GameObject PlayerTwoUI = GameObject.Find("Player 2 Panel");
        PlayerUIs = new List<GameObject> {PlayerOneUI, PlayerTwoUI};
        PlayerOneUI.SetActive(false);
        PlayerTwoUI.SetActive(false);

        using (StreamReader stream = new StreamReader("Assets/Towers.json"))
        {
            string TowersDataString = stream.ReadToEnd();
            Towers = JsonConvert.DeserializeObject<TowerDataSet>(TowersDataString);
        }
    }

    private void SetupUI(int WhichUI, int TowerSpotNum)
    {

        GameObject TowerSpot = GameObject.Find("Tower place " + TowerSpotNum);

        if (TowerSpot.transform.childCount == 0)
        {
            PlayerUIs[WhichUI].transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
            PlayerUIs[WhichUI].transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
            PlayerUIs[WhichUI].transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlayerUIs[WhichUI].transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
            PlayerUIs[WhichUI].transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;

            string TowerName = TowerSpot.transform.GetChild(0).gameObject.name;
            foreach (TowerData aTower in Towers.BaseTowers.Concat(Towers.UpgradedTowers))
            {
                if (aTower.Name == TowerName)
                {
                    bool HasUpgrades = Convert.ToBoolean(aTower.Upgrades.Count);
                    PlayerUIs[WhichUI].transform.GetChild(1).gameObject.GetComponent<Button>().interactable = HasUpgrades;
                    break;
                }
            }
        }

        PlayerUIs[WhichUI].SetActive(true);
        return;
    }

    private void SpawnTower(string TowerName, int Player, string WhichUI)
    {
        GameObject TowerSpot = GameObject.Find("Tower place " + PlayersInteract[Player]);

        if (TowerSpot.transform.childCount != 0)
        {
            Destroy(TowerSpot.transform.GetChild(0).gameObject);
        }

        GameObject NewTower = Instantiate(Resources.Load("Test Towers/" + TowerName)) as GameObject;
        NewTower.name = NewTower.name.Replace("(Clone)", "");
        NewTower.transform.SetParent(TowerSpot.transform, false);
        NewTower.transform.position = TowerSpot.transform.position;

        GameObject.Find(WhichUI + " Player " + (Player + 1) + " Panel").SetActive(false);
        EndInteraction(Player);

        return;
    }

    public void StartInteraction(int Player, int TowerSpotNum) 
    {
        if (PlayersInteract[1-Player] == TowerSpotNum)
        {
            Debug.Log("Tower spot is already being used");
            return;
        }

        PlayersInteract[Player] = TowerSpotNum;
        Behaviour PlayerMovement = GameObject.Find("Player " + (Player+1)).GetComponent<PlayerMovement>();
        PlayerMovement.enabled = false;

        SetupUI(Player, TowerSpotNum);

        return;
    }

    public void EndInteraction(int Player)
    {
        PlayersInteract[Player] = -1;

        PlayerUIs[Player].SetActive(false);

        Behaviour PlayerMovement = GameObject.Find("Player " + (Player+1)).GetComponent<PlayerMovement>();
        PlayerMovement.enabled = true;

        return;
    }

    public void SetTower(int Player)
    {
        Transform TowerPanel = GameObject.Find("Select menu").transform.Find("Set Tower Player " + (Player + 1) + " Panel");
        TowerPanel.gameObject.SetActive(true);

        if (TowerPanel.childCount > 2)
        {
            return;
        }

        float StartingPoint = TowerPanel.Find("Back").position.y;
        int ButtonNumber = 0;
        foreach (TowerData Data in Towers.BaseTowers)
        {
            ButtonNumber++;
            Button SpecificTowerButton = Instantiate(TowerButton);
            SpecificTowerButton.transform.SetParent(TowerPanel, false);
            SpecificTowerButton.transform.position = new Vector2(SpecificTowerButton.transform.position.x, StartingPoint - (ButtonNumber * 60));
            SpecificTowerButton.transform.Find("Name").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = Data.Name;
            SpecificTowerButton.transform.Find("Cost").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "A$" + Data.Price;
            SpecificTowerButton.onClick.AddListener(delegate{SpawnTower(Data.Name, Player, "Set Tower");});
        }

        return;
    }

    public void UpgradeTower(int Player)
    {
        Transform TowerPanel = GameObject.Find("Select menu").transform.Find("Upgrade Tower Player " + (Player + 1) + " Panel");
        TowerPanel.gameObject.SetActive(true);

        GameObject CurrentTower = GameObject.Find("Tower place " + PlayersInteract[Player]).transform.GetChild(0).gameObject;
        if (TowerPanel.childCount > 2)
        {
            int RemainingButtons = TowerPanel.childCount - 2;
            while (RemainingButtons > 0)
            {
                Destroy(TowerPanel.GetChild(1 + RemainingButtons).gameObject);
                RemainingButtons--;
            }
        }

        List<string> CurrentTowerUpgrades = new List<string>{"placeholder"};
        foreach (TowerData Data in Towers.BaseTowers.Concat(Towers.UpgradedTowers))
        {
            if (CurrentTower.name == Data.Name)
            {
                CurrentTowerUpgrades = new List<string>(Data.Upgrades);
                break;
            }
        }

        float StartingPoint = TowerPanel.Find("Back").position.y;
        int ButtonNumber = 0;
        foreach (TowerData UpgradedTower in Towers.UpgradedTowers)
        {
            if (CurrentTowerUpgrades.Contains(UpgradedTower.Name))
            {
                ButtonNumber++;
                Button SpecificTowerButton = Instantiate(TowerButton);
                SpecificTowerButton.transform.SetParent(TowerPanel, false);
                SpecificTowerButton.transform.position = new Vector2(SpecificTowerButton.transform.position.x, StartingPoint - (ButtonNumber * 60));
                SpecificTowerButton.transform.Find("Name").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = UpgradedTower.Name;
                SpecificTowerButton.transform.Find("Cost").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "A$" + UpgradedTower.Price;
                SpecificTowerButton.onClick.AddListener(delegate{SpawnTower(UpgradedTower.Name, Player, "Upgrade Tower");});
            }
        }
    }

    public void RemoveTower(int Player)
    {
        GameObject.Destroy(GameObject.Find("Tower place " + PlayersInteract[Player]).transform.GetChild(0).gameObject);

        EndInteraction(Player);

        return;
    }
}

[Serializable]
public class TowerDataSet
{
    public List<TowerData> BaseTowers { get; set; }
    public List<TowerData> UpgradedTowers { get; set; }
}

[Serializable]
public class TowerData
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public string Path { get; set; }
    public List<string> Upgrades { get; set; }
}