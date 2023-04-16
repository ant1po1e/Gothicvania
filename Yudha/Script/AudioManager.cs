using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    public AudioSource backgroundMusic, playerHit, enemyDead, gems, heal, arrow, lvlUp, flame, bossBGM, buttonUI, gameOver, bossDead;

    public static AudioManager instance;

    [Range(-80, 10)]
    public float masterVol, effectsVol;
    public Slider masterSlider, effectsSlider;

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
        masterSlider.value = masterVol;
        effectsSlider.value = effectsVol;

        masterSlider.minValue = -80;
        masterSlider.maxValue = 10;
        effectsSlider.minValue = -80;
        effectsSlider.maxValue = 10;
    }

    void Update()
    {

    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("masterVolume", masterVol);
    }

    public void EffectsVolume()
    {
        musicMixer.SetFloat("effectsVolume", effectsVol);
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void OnMasterVolumeChange()
    {
        masterVol = masterSlider.value;
        MasterVolume();
    }

    public void OnEffectsVolumeChange()
    {
        effectsVol = effectsSlider.value;
        EffectsVolume();
    }
}
