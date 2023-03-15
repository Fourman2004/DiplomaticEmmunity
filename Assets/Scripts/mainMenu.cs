using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class mainMenu : MonoBehaviour
{
    public GameObject Playbutton;
    public GameObject OptionsButton;
    public GameObject QuitButton;
    int Buttonnumber;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
        
    public void QuitGame()
    {
        Application.Quit();
    }

    public void menuNav()
    {
       if(Input.GetAxis("Joystick 7th Axis") == 1)
        {
            Buttonnumber++;
        }

    }
}
