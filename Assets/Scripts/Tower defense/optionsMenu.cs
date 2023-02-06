using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class optionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolume (float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
}
