using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingTowerBehavior : MonoBehaviour
{

    public float Range;

    public Transform Target;

    bool Detected = false;

    public GameObject ActiveIcon;

    Vector2 Direction;

    public GameObject Weapon;

    public GameObject Attack;

    public float AttackingRate;

    float nextTimeToAttack = 0;

    public Transform AttackPoint;

    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetpos = Target.position;

        Direction = targetpos - (Vector2)transform.position;

        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, Direction, 
            Range);

        if(rayinfo)
        {
            if(rayinfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    ActiveIcon.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }

            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    ActiveIcon.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }

        if(Detected)
        {
            Weapon.transform.up = Direction;
            if(Time.time > nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 1 / AttackingRate;
                combat();
            }
        }
    }

     void combat()
    {
       GameObject AttackIns = Instantiate(Attack, AttackPoint.position, Quaternion.identity);
        AttackIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
