using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Header("Audio Clips")]
    public AudioClip turretShoot;
    public AudioClip playerShoot;
    public AudioClip barnDamaged;
    public AudioClip emuDeath;
    public AudioClip gameLoss;
    public AudioClip gameWon;

    public void PlayAudio(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
