using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject resultText;
    public void StartGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) % SceneManager.sceneCountInBuildSettings);
    }

    public void ShowEndGameMenu(bool result)
    {
        if (result)
        {
            resultText.GetComponent<TextMeshProUGUI>().text = "You win";
        }
        else
        {
            resultText.GetComponent<TextMeshProUGUI>().text = "You lose";
        }
        gameObject.SetActive(true);
    }
}
