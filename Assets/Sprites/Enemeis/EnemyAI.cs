using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    public List<GameObject> Pathing = new List<GameObject>();
    private int currentTarget;

    private void Awake()
    {
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

        if(transform.position != goal.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, step);
            print(transform.position);
            print("Goal " + goal.transform.position);
            yield return null;
        }

        if (transform.position == goal.transform.position)
        {
            Pathing.Remove(goal);
        }
        if (Pathing.Capacity == 0)
        {
            print(Pathing.Capacity);
            yield break;
        }
        print(Pathing.Count);
        

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

    public void GainHoney()
    {
        //GameController.Honey += Value;
        Destroy(gameObject);
    }
}
