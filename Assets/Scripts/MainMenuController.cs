using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    public GameObject TutorialScreen;
    public GameObject CreditsScreen;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        TutorialScreen.SetActive(true);
    }

    public void CloseTutorial()
    {
        TutorialScreen.SetActive(false);
    }

    public void Credits()
    {
        CreditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsScreen.SetActive(false);
    }

}
