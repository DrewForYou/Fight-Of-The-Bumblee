/*
 * Controls waves spawning
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public List<Wave> Waves;
    public bool WaveOver;
    public bool TempStart;
    public int CurrentWave;
    public GameObject SpawnPoint;
    public CurrencyManager CurrencyManager;
    public GameManager GameManager;
    public TMP_Text WhatWave;
    public AudioClip StartSound;

    private void Start()
    {
        CurrencyManager = FindAnyObjectByType<CurrencyManager>();
        WaveOver = true;
    }

    private void Update()
    {
        if (WaveOver && TempStart)
        {
            if (CurrentWave < Waves.Count)
            {
                WaveOver = false;
                TempStart = false;
                WaveRun(Waves[CurrentWave]);
                //UpdateWave();
            }
        }
        if(WaveOver && CurrentWave >= Waves.Count)
        {
            GameManager.Win();
        }
    }

    //Initates wave. Note: To start a wave you need to go into game manager on the object this is
    //Attached to and enable TempStart.
    public void WaveRun(Wave wave)
    {
        for(int i = 0; i < wave.EnemyList.Count; i++)
        {
            StartCoroutine(EnemySpawn(wave.EnemyList[i], wave.EnemySpawns[i], wave.EnemySpawnDelay[i],
                wave));
        }
        CurrentWave += 1;
        AudioSource.PlayClipAtPoint(StartSound, Camera.main.transform.position);

        //Don't forget to impliment me.
        //GameManger.Reward(wave.WaveCompletionReward);

    }

    IEnumerator EnemySpawn(EnemyAI enemy, int count, float delay, Wave wave)
    {
        
        while(count != 0)
        {
            if(GameManager.IsRunning)
            {
                Instantiate(enemy, SpawnPoint.transform);
                count--;
            }
            yield return new WaitForSeconds(delay);
        }

        //Checks when all enemies are destroyed and spawned to then enable the next wave to come.
        //While this could be in it's own coroutine, I put it here
        while (!WaveOver)
        {
            if (FindAnyObjectByType<EnemyAI>() == null && HasEverythingSpawned(enemy, wave))
            {
                WaveOver = true;
                CurrencyManager.AddCurrency(wave.WaveCompletionReward);
            }
            yield return null;
        }
    }

    //This checks to make sure all enemies have been spawned
    public bool HasEverythingSpawned(EnemyAI enemy, Wave wave)
    {
        bool AllDone = false;
        wave.EnemyTypeIsFinished[wave.EnemyList.IndexOf(enemy)] = true;
        for (int i = 0; i < wave.EnemyTypeIsFinished.Count; i++)
        {
            if (wave.EnemyTypeIsFinished[i] == false)
            {
                AllDone = false;
                break;
            }
            else
            {
                AllDone = true;
            }
        }

        if (AllDone)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }
    
    /*
    public void UpdateWave()
    {
        WhatWave.text = "Wave: " + CurrentWave;
    }
    */
}
