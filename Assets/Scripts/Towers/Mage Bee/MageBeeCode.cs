using System.Collections;
using System.Collections.Generic;
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
    float nextTimeToBaseAttack = 0;
    float nextTimeToFireballAttack = 0;
    float nextTimeToLightningAttack = 0;
    public Transform AttackPoint;
    public float Force;
    bool Detected = false;
    bool FireballOn = false;
    bool LightningOn = false;
    public List<GameObject> EnemyTargets;

 
    // Update is called once per frame
    void Update()
    {
        if (EnemyTargets.Count > 0)
        {
            Vector2 targetpos = EnemyTargets[0].transform.position;

            Direction = targetpos - (Vector2)transform.position;

            if (Detected)
            {
                //Determiens when to fire base attack
                Weapon.transform.up = Direction;
                if (Time.time > nextTimeToBaseAttack)
                {
                    // print(targetpos);
                    nextTimeToBaseAttack = Time.time + 1 / BaseAttackingRate;
                    Combat(BaseAttack);
                }

                //Determines when to fire fireball
                if (Time.time > nextTimeToFireballAttack && FireballOn)
                {
                    // print(targetpos);
                    nextTimeToFireballAttack = Time.time + 1 / FireballAttackingRate;
                    Combat(FireBall);
                }

                //Deteremines when to fire lightning
                if (Time.time > nextTimeToLightningAttack && LightningOn)
                {
                    // print(targetpos);
                    nextTimeToLightningAttack = Time.time + 1 / LightningAttackingRate;
                    //Needs it's own version of Combat.
                }

            }
        }
    }

    void Combat(GameObject attack)
    {
        GameObject AttackIns = Instantiate(attack, AttackPoint.position, Quaternion.identity);
        AttackIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
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
}
