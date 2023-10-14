using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArcherBeeTower : MonoBehaviour
{
    public float AttackRange;
    public float AttackDamage;

    private float attackRate = 1f;
    private float rotationSpeed = 200f;
    private float nextTimeToAttack;

    public Transform ArcherRotationPoint;
    public Transform ArrowSpawnPoint;

    private Transform target;

    public GameObject ArrowPrefab;

    public LayerMask EnemyMask;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        // this checks if an enemy is within the attack range
        if (!CheckTargetIsInRange())
        {
            target = null;
        }

        else
        {
            nextTimeToAttack += Time.deltaTime;

            // if the next time to attack is >= the attack rate, perform an attack
            if (nextTimeToAttack >= 1f/ attackRate)
            {
                // calls on the shoot function
                Shoot();

                // resets the next time to attack
                nextTimeToAttack = 0f;
            }
        }
    }

    private void Shoot()
    {
        // instantiate the arrow at the set spawnpoint 
        GameObject Arrow = Instantiate(ArrowPrefab, ArrowSpawnPoint.position, Quaternion.identity);

        ArrowBehaviour arrowBehaviour = Arrow.GetComponent<ArrowBehaviour>();

        // this sets the target for the arrow to the current target/enemy
        arrowBehaviour.SetTarget(target);

    }
    private void FindTarget()
    {
        // this creates a circle around the archer & lets you find enemies within
        // the attack range
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 
            AttackRange, (Vector2)transform.position, 0f, EnemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        // makes sure the target is within the attack range of the archer
        return Vector2.Distance(target.position, transform.position) <= AttackRange; 
    }
    private void RotateTowardsTarget()
    {
        // calculates the angle to rotate the archer to face enemies
        float angle = Mathf.Atan2(target.position.y - transform.position.y, 
            target.position.x - transform.position.x) * Mathf.Rad2Deg + 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // rotates the archer over time towards the target
        ArcherRotationPoint.rotation = Quaternion.RotateTowards
            (ArcherRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        // this draws a red circle around the archer bee
        Handles.color = Color.red;

        // the red circle is the bee's attack range
        Handles.DrawWireDisc(transform.position, transform.forward, AttackRange);
    }
    public void Upgrade1()
    {
        AttackRange = 4f;
        attackRate = 3f;
    }

    public void Upgrade2()
    {
        AttackDamage = 2f;
        AttackRange = 5f;
    }

    public void Upgrade3()
    {
        AttackDamage = 3f;
        attackRate = 5f;
    }
    
}
