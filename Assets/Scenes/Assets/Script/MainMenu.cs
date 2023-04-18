using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MainMenu : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject creditsPanel;
    public GameObject creditsPanel2;
    public GameObject prologPanel;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            AudioManager.instance.backgroundMusic.Stop();
        }
        Time.timeScale = 1;
        optionPanel.SetActive(false);
        creditsPanel.SetActive(false);
        creditsPanel2.SetActive(false);
        prologPanel.SetActive(false);
    }

    void Update()
    {

    }

    public async void StartGame()
    {
        PlayButtonClickSound();
        AudioManager.instance.backgroundMusic.Stop();
        prologPanel.SetActive(true);
        Time.timeScale = 1;
        await Task.Delay(9000);
        SceneManager.LoadScene(1);
        AudioManager.instance.backgroundMusic.Play();
        prologPanel.SetActive(false);
    }

    public void Options()
    {
        PlayButtonClickSound();
        optionPanel.SetActive(true);
    }

    public void OptionsClosed()
    {
        PlayButtonClickSound();
        optionPanel.SetActive(false);
    }

    public void Credits()
    {
        PlayButtonClickSound();
        creditsPanel.SetActive(true);
    }

    public void CreditsClosed()
    {
        PlayButtonClickSound();
        creditsPanel.SetActive(false);
    }

    public void CreditsNext()
    {
        PlayButtonClickSound();
        creditsPanel.SetActive(false);
        creditsPanel2.SetActive(true);
    }

    public void CreditPrev()
    {
        PlayButtonClickSound();
        creditsPanel.SetActive(true);
        creditsPanel2.SetActive(false);
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
        print("Game Closed");
    }

    public void PlayButtonClickSound()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.buttonUI);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
