using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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

    public void EnemyMove()
    {
        //Set up corotine that takes a positoin from the list and runs till the enemy reaches that point.
    }

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
