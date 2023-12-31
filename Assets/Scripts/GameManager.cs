using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Health;
    public int Honey;
    // public GameObject StartWaveButton;    know when wave has ended, know when
    // wave has started, keep track of health & currency
    public List<GameObject> MapPoints;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject PauseScreen;
    public TMP_Text healthText;
    public bool IsRunning = true;
    public bool SpeedMultiply;
    private bool alreadySpeedy;

    public void Hurt(int damage)
    {
        Health -= damage;
        healthText.text = ": " + Health.ToString();
        if (Health <= 0 )
        {
            LoseScreen.SetActive(true);
            IsRunning = false;
        }
    }

    private void Update()
    {
        if(SpeedMultiply && !alreadySpeedy)
        {
            Time.timeScale = 2;
            alreadySpeedy = true;
        }
        else if(!SpeedMultiply && alreadySpeedy) 
       {
            Time.timeScale = 1;
            alreadySpeedy = false;
        }
    }
    
    public void Win()
    {
        WinScreen.SetActive(true);
        IsRunning = false;
    }

    public void Pause()
    {
        if(IsRunning)
        {
            IsRunning = false;
            PauseScreen.SetActive(true);
        }
        else
        {
            IsRunning = true;
            PauseScreen.SetActive(false);
        }
    }

    public void SpeedUp()
    {
        SpeedMultiply = !SpeedMultiply;
    }
}
