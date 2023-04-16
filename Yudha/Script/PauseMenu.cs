using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject GUI;
    public GameObject audioManager;
    bool isPaused;
    
    void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        Pause();
    }

    public void Pause()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PlayButtonClickSound();
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            GUI.SetActive(false);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            PlayButtonClickSound();
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            GUI.SetActive(true);
            isPaused = false;
        }
    }

    public void PlayButtonClickSound()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.buttonUI);
    }
}
