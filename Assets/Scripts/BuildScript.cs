using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour
{
    public GameObject buildButton;
    public Button cropButton;
    public Image sideMenuImage;
    public GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress() {
        
        sideMenuImage.transform.position = new Vector3(200, 236, 0);
    }
    public void CropsPress() {
        buildButton.SetActive(false);
        sprite.SetActive(true);
    }


}
