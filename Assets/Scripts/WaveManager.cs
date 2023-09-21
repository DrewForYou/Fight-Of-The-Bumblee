/*
 * Controls waves spawning
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> Waves;
    public bool WaveOver;
    public bool TempStart;
    public int CurrentWave;
    public GameObject SpawnPoint;

    private void Start()
    {
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
            }
        }
    }

    public void WaveRun(Wave wave)
    {
        for(int i = 0; i < wave.EnemyList.Count; i++)
        {
            StartCoroutine(EnemySpawn(wave.EnemyList[i], wave.EnemySpawns[i], wave.EnemySpawnDelay[i],
                wave));
        }
        CurrentWave += 1;
        
    }

    IEnumerator EnemySpawn(EnemyAI enemy, int count, float delay, Wave wave)
    {
        
        while(count != 0)
        {
            print("Got to Corutine");
            Instantiate(enemy, SpawnPoint.transform);
            count--;
            yield return new WaitForSeconds(delay);
        }

        while (!WaveOver)
        {
            if (FindAnyObjectByType<EnemyAI>() == null)
            {
                WaveOver = true;
                print("I have been run");
            }
            yield return null;
        }
        //old way of figuring out when all enemies have been spawned
        /*
        bool AllDone = false;
        wave.EnemyTypeIsFinished[wave.EnemyList.IndexOf(enemy)] = true;
        for(int i = 0; i < wave.EnemyTypeIsFinished.Count; i++)
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

        if(AllDone)
        {
            WaveOver = true; 
        }
        */
        print("Exited corutine");
    }
}
