using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class EndPhase : MonoBehaviour
{
    public GameObject Scoreboardbutton, Quitbutton;
    private bool SbB, Qb;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Submit") == 1)
        {
         SbB = true;
         Qb = false;
            UINAV();

        }
        else
        {
            Qb = true;
            SbB = false;
            UINAV();
        }
    }

    public static void moveToScores() {
        SceneManager.LoadScene("ScoreboardScene");
    }

    public static void exitGame() {
        Application.Quit();
    }

    void UINAV()
    {
     if (SbB)
        {
            EventSystem.current.SetSelectedGameObject(Scoreboardbutton);
        }
     else if(Qb)
        {
            EventSystem.current.SetSelectedGameObject(Quitbutton);
        }
    }
}
