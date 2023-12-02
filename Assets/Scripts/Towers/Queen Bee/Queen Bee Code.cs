using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueenBeeCode : Tower
{
    public GameObject BeeDrone;
    public GameObject SpawnPoint;
    public GameManager GameManager;
    public WaveManager WaveManager;
    public List<GameObject> Pathing;
    public float NextTimeToAttack = 0;
    public int Damage;
    public float Speed;
    public Coroutine QueenBeeDronesRef;
    //public TowerSelectUI SelectUI;

    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        WaveManager = FindAnyObjectByType<WaveManager>();
       /* SelectUI = FindAnyObjectByType<TowerSelectUI>();
        SelectUI.QueenPlaced = true;*/

        Pathing = new List<GameObject>(GameManager.MapPoints);
        Pathing.Reverse();
        SpawnPoint = Pathing[0];
    }

    private void Update()
    {
        if(!WaveManager.WaveOver)
        {
            if(QueenBeeDronesRef == null)
            {
                QueenBeeDronesRef = StartCoroutine(QueenBeeDrones());
            }
        }
    }

    IEnumerator QueenBeeDrones()
    {
        while (!WaveManager.WaveOver)
        {
            if (GameManager.IsRunning)
            {
                Instantiate(BeeDrone, SpawnPoint.transform);
            }
            yield return new WaitForSeconds(NextTimeToAttack);
        }
        QueenBeeDronesRef = null;
    }
}
