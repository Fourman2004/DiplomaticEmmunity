using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPhase : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void moveToScores() {
        SceneManager.LoadScene("ScoreboardScene");
    }

    public static void exitGame() {
        Application.Quit();
    }
}
