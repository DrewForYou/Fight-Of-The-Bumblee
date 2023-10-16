using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MageBeeCode : MonoBehaviour
{
    //public GameObject ActiveIcon;
    public GameObject Weapon;
    public GameObject BaseAttack;
    public GameObject FireBall;
    public GameObject Freeze;
    public GameObject Lightning;
    public float BaseAttackingRate;
    public float FireballAttackingRate;
    public float LightningAttackingRate;
    public Vector2 Direction;
    public Vector2 Direction2;
    public Vector2 Direction3;
    float nextTimeToBaseAttack = 0;
    float nextTimeToFireballAttack = 0;
    float nextTimeToLightningAttack = 0;
    public Transform AttackPoint;
    public float Force;
    bool Detected = false;
    public bool FireballOn = false;
    public bool LightningOn = false;
    public List<GameObject> EnemyTargets;
    

 
    // Update is called once per frame
    void Update()
    {
        if (EnemyTargets.Count > 0)
        {
            Vector2 targetpos = EnemyTargets[0].transform.position;
            Vector2 targetpos2;
            Vector2 targetpos3;

            Direction = targetpos - (Vector2)transform.position;

            
            //Determiens when to fire base attack
            Weapon.transform.up = Direction;
            if (Time.time > nextTimeToBaseAttack)
            {
                if(Detected)
                {
                    nextTimeToBaseAttack = Time.time + 1 / BaseAttackingRate;
                    Combat(BaseAttack, Direction);
                    //BaseAttackTarget();
                }

            }
            //Determines when to fire fireball
            if (Time.time > nextTimeToFireballAttack && FireballOn)
            {
                if (Detected)
                {
                    nextTimeToFireballAttack = Time.time + 1 / FireballAttackingRate;
                    Combat(FireBall, Direction);
                    //FireballTarget();
                }
            }
            
            //Deteremines when to fire lightning
            if (Time.time > nextTimeToLightningAttack && LightningOn)
            {
                if (Detected)
                {
                    if (EnemyTargets.Count > 2)
                    {
                        targetpos3 = EnemyTargets[2].transform.position;
                        Direction3 = targetpos3 - (Vector2)transform.position;

                        Combat(Lightning, Direction3);
                    }

                    if (EnemyTargets.Count > 1)
                    {
                        targetpos2 = EnemyTargets[1].transform.position;
                        Direction2 = targetpos2 - (Vector2)transform.position;
                        Combat(Lightning, Direction2);
                    }

                    nextTimeToLightningAttack = Time.time + 1 / LightningAttackingRate;
                    Combat(Lightning, Direction);
                }
            }
        }
    }

    void Combat(GameObject attack, Vector2 direction)
    {
        GameObject AttackIns = Instantiate(attack, AttackPoint.position, Quaternion.identity);
        AttackIns.GetComponent<Rigidbody2D>().AddForce(direction * Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAI>())
        {
            EnemyTargets.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAI>())
        {
            //ActiveIcon.GetComponent<SpriteRenderer>().color = Color.green;
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAI>())
        {
            //ActiveIcon.GetComponent<SpriteRenderer>().color = Color.red;
            Detected = false;
        }
        if (EnemyTargets.Contains(collision.gameObject))
        {
            EnemyTargets.Remove(collision.gameObject);
        }
    }

    public void Upgrade1()
    {
        FireballOn = true;
    }

    public void Upgrade2()
    {
        Freeze.gameObject.SetActive(true);
    }

    public void Upgrade3()
    {
        LightningOn = true;
    }

    /*
    public void BaseAttackTarget()
    {
        Vector2 targetpos = EnemyTargets[0].transform.position;
        Direction = targetpos - (Vector2)transform.position;
        Weapon.transform.up = Direction;
        Combat(BaseAttack, Direction);
    }

    public void FireballTarget()
    {
        Vector2 targetpos = EnemyTargets[0].transform.position;
        Direction = targetpos - (Vector2)transform.position;
        Weapon.transform.up = Direction;
        Combat(FireBall, Direction);
    }

    public void LightningTarget()
    {

    }*/
}
