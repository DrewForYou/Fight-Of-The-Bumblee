using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int Health;
    public int Strength;
    public int Value;
    public float Speed;
    public Rigidbody2D EnemyRB;
    public Collider2D EnemyCollider;
    public List<GameObject> Pathing;
    public GameManager GameManager;
    //private int currentTarget;


    private void Awake()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        Pathing = new List<GameObject>(GameManager.MapPoints);
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
        float step = Time.deltaTime * Speed;

        while (Vector3.Distance(transform.position, goal.transform.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, step);
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

    //Damages the enemy and checks if it has died
    public void Damaged(int damage)
    {
        Health -= damage;
        if(Health <= 0 )
        {
            GainHoney();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Impliment Proejctile Damage
        if(collision.gameObject.tag == "Projectile")
        {
            /*Impliment getting damage type*/
            Damaged(1);
            //Damaged(collision.GetComponenet
        }
    }

    public void GainHoney()
    {
        //GameManager.Honey += Value;
        Destroy(gameObject);
    }

    public void ReachedEnd()
    {
        //GameManager.HiveDamaged(Damage);
        Destroy(gameObject);
    }
}
