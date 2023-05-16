using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int emuSpawn = 1;
    public TimerScript timerScript;
    public string hasWon = "idk";
    private bool gameRunning = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning == true)
        {
            if (timerScript.checkEnd() == "won")
            {
                GameWon();
            }
            else if (timerScript.checkEnd() == "lose")
            {
                GameLose();
            }
        }
        else if (gameRunning == false)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        
    }

    public void GameLose()
    {
        hasWon = "lose";
        gameRunning = false;
    }

    public void GameWon()
    {
        hasWon = "won";
        gameRunning = false;
        // Audio
        AudioClip winClip = GameObject.Find("Game Manager").GetComponent<AudioManager>().gameWon;
        GameObject.Find("Game Manager").GetComponent<AudioManager>().audioSource.PlayOneShot(winClip);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(1).name);
    }
}
