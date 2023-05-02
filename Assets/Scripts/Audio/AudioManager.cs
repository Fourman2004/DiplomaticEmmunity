using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip turretShoot;
    public AudioClip playerShoot;
    public AudioClip playerReload;
    public AudioClip barnDamaged;
    public AudioClip emuDeath;
    public AudioClip gameLoss;
    public AudioClip gameWon;
}
