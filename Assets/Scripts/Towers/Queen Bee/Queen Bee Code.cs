using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBeeCode : Tower
{
    public GameObject BeeDrone;
    public GameManager GameManager;
    public WaveManager WaveManager;
    public float AttackingRate;
    float nextTimeToAttack = 0;
    public int UpgradeLevel = 0;
    public int Damage = 3;

    void Update()
    {
       
        if (GameManager.IsRunning && !WaveManager.WaveOver)
        {
           
        }
    }


    public override void Upgrade1()
    {

    }
    public override void Upgrade2()
    {
       
    }
    public override void Upgrade3()
    {
        
    }
}
