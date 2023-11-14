using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
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
            // calculates the direction of the bullet to the enemy
            Vector2 direction = (Target.position - transform.position);

            // this calculates the angle to point the bullet towards the enemy
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

            // this rotates the bullet so it will face the enemy
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // moves the bullet in the calculated direction 
            Rb2d.velocity = direction * bulletSpeed;
        }
    }
    public void SetTarget(Transform target)
    {
        // sets the enemy the bullet will follow
        Target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the bullet collides with an enemy, destroy the bullet
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                enemy.Damaged(Damage); 
            }

            Destroy(gameObject);
        }
    }
}
