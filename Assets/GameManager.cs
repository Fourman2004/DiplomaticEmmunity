using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                hasWon = "won";
                gameRunning = false;
                // Audio
                AudioClip winClip = GameObject.Find("Game Manager").GetComponent<AudioManager>().gameWon;
                GameObject.Find("Game Manager").GetComponent<AudioManager>().audioSource.PlayOneShot(winClip);
            }
            else if (timerScript.checkEnd() == "lose")
            {
                hasWon = "lose";
                gameRunning = false;
            }
        }
        else if (gameRunning == false)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        
    }
}
