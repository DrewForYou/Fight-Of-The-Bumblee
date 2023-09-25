using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Health;
    public int Honey;
    // public GameObject StartWaveButton;    know when wave has ended, know when
    // wave has started, keep track of health & currency
    public List<GameObject> MapPoints;

    public void Hurt(int damage)
    {
        Health -= damage;
        if (Health <= 0 )
        {
            print("Game Over");
        }
    }
}
