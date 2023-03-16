using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject Playbutton;
    public GameObject OptionsButton;
    public GameObject QuitButton;
    bool PB,OP,QB;
    public bool controllerSetting = false;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
        
    public void QuitGame()
    {
        Application.Quit();
    }

    public void UINavigation()
    {
        if (PB)
        {
            EventSystem.current.SetSelectedGameObject(Playbutton);
            if (controllerSetting == false)
            {
                PlayButton();
            }
            else
            {
                ButtonPress();
            }
            
        }
        else if (OP)
        {
            EventSystem.current.SetSelectedGameObject(OptionsButton);
            if (controllerSetting == false)
            {

            }
            else
            {
                ButtonPress();
            }
        }
        else if (QB)
        {
            EventSystem.current.SetSelectedGameObject(QuitButton);
            if (controllerSetting == false)
            {
                QuitGame();
            }
            else
            {
                ButtonPress();
            }
        }
    }

    public void ButtonPress()
    {
        if (PB && Input.GetButton("ControllerInteract"))
        {
            PlayButton();
        }
        else if(QB && Input.GetButton("ControllerInteract"))
        {
            QuitGame();
        }
    }


    public void Update()
    {

        if (Input.GetAxisRaw("Submit") == 1)
        {
            PB = false;
            OP = true;
            QB = false;
            UINavigation();
        }
        else if (Input.GetAxisRaw("Submit") == -1)
        {
            PB = true;
            OP = false;
            QB = false;
            UINavigation();
        }
       else
        {
            PB = false;
            OP = false;
            QB = true;
            UINavigation();
        }
    }

}