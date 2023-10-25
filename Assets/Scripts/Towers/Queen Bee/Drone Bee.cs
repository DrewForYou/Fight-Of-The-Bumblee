using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBee : MonoBehaviour
{
    public int Strength;
    public int Value;
    public float Speed;
    public Rigidbody2D DroneRB;
    public Collider2D DroneCollider;
    public List<GameObject> Pathing;
    public GameManager GameManager;
    public WaveManager WaveManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        WaveManager = FindAnyObjectByType<WaveManager>();

        Pathing = new List<GameObject>(GameManager.MapPoints);
        Pathing.Reverse();
        EnemyMove();
    }

    //Moves the enemy
    public void EnemyMove()
    {
        StartCoroutine(MoveMe(Pathing[0]));

        //Set up corotine that takes a positoin from the list and runs till the enemy reaches that point.
    }

    //Goes through and moves the enemy to the current target
    private IEnumerator MoveMe(GameObject goal)
    {
        while (Vector3.Distance(transform.position, goal.transform.position) > 0.2f)
        {
            if (GameManager.IsRunning)
            {
                transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, Time.deltaTime * Speed);
            }
            yield return null;
        }

        //print(Pathing.Count);
        Pathing.Remove(goal);

        if (Pathing.Count > 0)
        {
            EnemyMove();
        }
        else
        {
            ReachedEnd();
        }
    }

    public void ReachedEnd()
    {
        GameManager.Hurt(Strength);
        Destroy(gameObject);
    }
}
