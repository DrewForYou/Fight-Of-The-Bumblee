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
    //public bool StopGame 
    public TMP_Text healthText;

    public void Hurt(int damage)
    {
        Health -= damage;
        healthText.text = ": " + Health.ToString();
        if (Health <= 0 )
        {
            LoseScreen.SetActive(true);
            //StopGame = true;
        }
    }

    public void Win()
    {
        WinScreen.SetActive(true);
        //StopGame = true;
    }
}
