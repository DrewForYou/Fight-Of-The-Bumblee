using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBeeCode : Tower
{
    //this is the circle that is used for debugging. just to show if
    //green = attacking red = no attacking  blue = just got upgraded
  //  public GameObject ActiveIcon;


    Vector2 Direction;

    //this is the weapon the bee will be holding EX: for the archer this would be the bow
    public GameObject Weapon;

    //the gameobject that will be used for the attack EX: the arrow
    public GameObject Attack;

    //how often it attacks
    public float AttackingRate;


    float nextTimeToAttack = 0;

    //the place it shoots from
    public Transform AttackPoint;

    //how fast it shoots
    public float Force;

    //Knows when enemies are in the trigger
    bool Detected = false;

    //list of enemies
    public List<GameObject> EnemyTargets;

    public int UpgradeLevel = 0;

    public int Damage = 3;

    // Update is called once per frame
    void Update()
    {
        //just saying 
        if (EnemyTargets.Count > 0)
        {
            Vector2 targetpos = EnemyTargets[0].transform.position;

            Direction = targetpos - (Vector2)transform.position;

            if (Detected)
            {
                Weapon.transform.up = Direction;
                if (Time.time > nextTimeToAttack)
                {

                    nextTimeToAttack = Time.time + 1 / AttackingRate;
                    combat();
                }
            }
        }
    }

    void combat()
    {
        GameObject AttackIns = Instantiate(Attack, AttackPoint.position, Quaternion.identity);
        AttackIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyTargets.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ActiveIcon.GetComponent<SpriteRenderer>().color = Color.green;
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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
        if(UpgradeLevel == 0)
        {
            AttackingRate = 2;
            ++UpgradeLevel;
        }
    }
    public override void Upgrade2()
    {
        if (UpgradeLevel == 1)
        {
            Damage = 6;
            ++UpgradeLevel;
        }
    }
    public override void Upgrade3()
    {
        if (UpgradeLevel == 2)
        {
            AttackingRate = 5;
            ++UpgradeLevel;
        }
    }
}
