using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBee : MonoBehaviour
{
    public int Damage;
    public float Speed;
    public Rigidbody2D DroneRB;
    public Collider2D DroneCollider;
    public List<GameObject> Pathing;
    public GameManager GameManager;
    public WaveManager WaveManager;
    public QueenBeeCode QueenBeeCode;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        WaveManager = FindAnyObjectByType<WaveManager>();
        QueenBeeCode = FindAnyObjectByType<QueenBeeCode>();

        Damage = QueenBeeCode.Damage;
        Speed = QueenBeeCode.Speed;

        Pathing = new List<GameObject>(GameManager.MapPoints);
        Pathing.Reverse();
        DroneMove();
    }

    //Moves the enemy
    public void DroneMove()
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
            DroneMove();
        }
        else
        {
            ReachedEnd();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyAI>().Damaged(Damage);
            Destroy(this.gameObject);
        }
    }

    public void ReachedEnd()
    {
        Destroy(gameObject);
    }
}
