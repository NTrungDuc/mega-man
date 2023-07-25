using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Canvas Pause;
    public void playAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.volume = 1f;
    }
    public void quit()
    {
        Application.Quit();
    }
    public void resume()
    {
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
    public void pause()
    {
        Pause.gameObject.SetActive(true);
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }
}
