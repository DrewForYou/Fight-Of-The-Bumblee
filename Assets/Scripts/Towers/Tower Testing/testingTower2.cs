using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingTower2 : MonoBehaviour
{

   // public Transform Target;
    
    public GameObject ActiveIcon;
    
    Vector2 Direction;

    public GameObject Weapon;

    public GameObject Attack;

    public float AttackingRate;

    float nextTimeToAttack = 0;

    public Transform AttackPoint;

    public float Force;

    bool Detected = false;

    public List<GameObject> EnemyTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyTargets.Count > 0)
        {
            Vector2 targetpos = EnemyTargets[0].transform.position;

            Direction = targetpos - (Vector2)transform.position;

            if (Detected)
            {
                Weapon.transform.up = Direction;
                if (Time.time > nextTimeToAttack)
                {
                   // print(targetpos);
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
        if (collision.gameObject.tag == "Player")
        {
            EnemyTargets.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActiveIcon.GetComponent<SpriteRenderer>().color = Color.green;
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActiveIcon.GetComponent<SpriteRenderer>().color = Color.red;
            Detected = false;
        }
        if(EnemyTargets.Contains(collision.gameObject))
        {
            EnemyTargets.Remove(collision.gameObject);
        }
    }


}
