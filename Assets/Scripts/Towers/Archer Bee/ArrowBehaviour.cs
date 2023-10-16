using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private float bulletSpeed = 5f;
    public int Damage;

    private Transform Target;

    public Rigidbody2D Rb2d;


    private void FixedUpdate()
    {
        // checks there's a target
        if (Target != null)
        {
            // calculates the direction of the arrow to the enemy
            Vector2 direction = (Target.position - transform.position);

            // this calculates the angle to point the arrow towards the enemy
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

            // this rotates the arrow so it will face the enemy
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // moves the arrow in the calculated direction 
            Rb2d.velocity = direction * bulletSpeed;

        }
    }

    public void SetTarget(Transform target)
    {
        // sets the enemy the arrow will follow
        Target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the arrow collides with an enemy, destroy the arrow 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                enemy.Damaged(Damage);
                Debug.Log("Arrow hit enemy" + enemy.Health);
            }
            //collision.GetComponent<EnemyAI>().Damaged(Damage);
            Destroy(gameObject);
        }
    }
}
