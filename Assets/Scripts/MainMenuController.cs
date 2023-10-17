using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void StartGame()
    {
        playerController.StartGame();
    }

    public void QuitGame()
    {
        playerController.QuitGame();
    }

    /*
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
    */
}
