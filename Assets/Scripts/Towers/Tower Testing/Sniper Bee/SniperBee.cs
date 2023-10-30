using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SniperBee : Tower
{
    public int AttackDamage;
    public float AttackRange;

    private float rotationSpeed = 200f;
    private float nextTimeToAttack;
    public float delayShots = 8f;

    public Transform SniperRotationPoint;
    public Transform BulletSpawnPoint;

    private Transform target;

    public GameObject BulletPrefab;

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
            if (nextTimeToAttack <= Time.time)
            {
                Shoot();

                // waits a couple of seconds before the next shot
                nextTimeToAttack = Time.time + delayShots;
            }
        }
    }

    private void Shoot()
    {
        // instantiate the arrow at the set spawnpoint 
        GameObject Bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);

        BulletBehaviour bulletBehaviour = Bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.Damage = AttackDamage;
        // this sets the target for the arrow to the current target/enemy
        bulletBehaviour.SetTarget(target);

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
        // makes sure the target is within the attack range of the sniper
        return Vector2.Distance(target.position, transform.position) <= AttackRange;
    }
    private void RotateTowardsTarget()
    {
        // calculates the angle to rotate the sniper to face enemies
        float angle = Mathf.Atan2(target.position.y - transform.position.y,
            target.position.x - transform.position.x) * Mathf.Rad2Deg + 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // rotates the sniper over time towards the target
        SniperRotationPoint.rotation = Quaternion.RotateTowards
            (SniperRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        // this draws a red circle around the sniper bee
        Handles.color = Color.red;

        // the red circle is the bee's attack range
        Handles.DrawWireDisc(transform.position, transform.forward, AttackRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                enemy.Damaged(AttackDamage);    
            }
        }
    }
   
    public override void Upgrade1()
    {
        AttackRange = 9f;
        AttackDamage = 2;

        Level = 1;
        //UpgradeButton.Instance.SelectedTower(this);

    }
    public override void Upgrade2()
    {
        delayShots = 6f;
        Level = 2;
        //UpgradeButton.Instance.SelectedTower(this);
    }
    public override void Upgrade3()
    {
        delayShots = 4f;
        Level = 3;
        //UpgradeButton.Instance.SelectedTower(this);
    }
}
