/*
 * Data Class That Holds info for waves
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public List<EnemyAI> EnemyList;
    public List<int> EnemySpawns;
    public List<float> EnemySpawnDelay;
    public List<bool> EnemyTypeIsFinished;
    public int WaveCompletionReward;
}
