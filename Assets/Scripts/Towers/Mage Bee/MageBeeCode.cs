using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MageBeeCode : Tower
{
    //public GameObject ActiveIcon;
    public GameObject Weapon;
    public GameObject BaseAttack;
    public GameObject FireBall;
    public GameObject Freeze;
    public GameObject Lightning;
    public GameObject UpgradeSprite1;
    public GameObject UpgradeSprite2;
    //public GameObject UpgradeSprite3;
    public float BaseAttackingRate;
    public float FireballAttackingRate;
    public float LightningAttackingRate;
    public Vector2 Direction;
    //public Vector2 Direction2;
    //public Vector2 Direction3;
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
            if(GetFirstEnemy() != null)
            {
                /*Vector2 targetpos2;
                Vector2 targetpos3;*/

                //Determiens when to fire base attack
                Weapon.transform.up = Direction;
                if (Time.time > nextTimeToBaseAttack)
                {
                    if (Detected && GetFirstEnemy() != null)
                    {
                        nextTimeToBaseAttack = Time.time + 1 / BaseAttackingRate;
                        Combat(BaseAttack, Direction);
                        //BaseAttackTarget();
                    }

                }
                //Determines when to fire fireball
                if (Time.time > nextTimeToFireballAttack && FireballOn)
                {
                    if (Detected && GetFirstEnemy() != null)
                    {
                        nextTimeToFireballAttack = Time.time + 1 / FireballAttackingRate;
                        Combat(FireBall, Direction);
                        //FireballTarget();
                    }
                }

                //Deteremines when to fire lightning
                if (Time.time > nextTimeToLightningAttack && LightningOn)
                {
                    if (Detected && GetFirstEnemy() != null)
                    {
                        /*
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
                        }*/

                        nextTimeToLightningAttack = Time.time + 1 / LightningAttackingRate;
                        Combat(Lightning, Direction);
                    }
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

    public override void Upgrade1()
    {
        FireballOn = true;
        UpgradeSprite1.gameObject.SetActive(true);
    }

    public override void Upgrade2()
    {
        Freeze.gameObject.SetActive(true);
        UpgradeSprite2.SetActive(true);
    }

    public override void Upgrade3()
    {
        LightningOn = true;
    }

    public GameObject GetFirstEnemy()
    {
        for(int i = 0; i < EnemyTargets.Count; i++)
        {
            if (EnemyTargets[i] != null)
            {
                Direction = (Vector2) EnemyTargets[i].transform.position - (Vector2)transform.position;
                return EnemyTargets[i];
            }
        }
        return null; 
    }
}
