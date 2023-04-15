using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer music, effects;   // Start is called before the first frame update

    public AudioSource backgroundMusic, hit, enemyDead, gems;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayAudio(backgroundMusic);
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
