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
        if(WaveOver && TempStart)
        {
            if(CurrentWave < Waves.Count)
            {
                WaveOver = false;
                StartCoroutine(WaveRun(Waves[CurrentWave]));
            }
        }
    }

    IEnumerator WaveRun(Wave wave)
    {
        Instantiate(wave.EnemyList[0], SpawnPoint.transform);

        yield return null;
        CurrentWave += 1;
        WaveOver = true;
    }
}
