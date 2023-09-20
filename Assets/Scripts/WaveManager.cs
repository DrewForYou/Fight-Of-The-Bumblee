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
        WaveOver = true;
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
        print("Exited corutine");
    }
}
