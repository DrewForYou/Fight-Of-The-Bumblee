using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkedArcherBee : Tower
{
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

    public WaveManager WaveManager;

    public int Damage = 3;

    public GameObject upgrade0;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;

    // Update is called once per frame

    public AudioClip upgrade;

    void Awake()
    {
        WaveManager = FindAnyObjectByType<WaveManager>();
    }

    void Update()
    {
        //just saying 
        if (EnemyTargets.Count > 0)
        {
            GrabTarget();

            if (Detected && GetFirstEnemy() != null)
            {
                Weapon.transform.up = Direction;
                if (Time.time > nextTimeToAttack)
                {
                    nextTimeToAttack = Time.time + 1 / AttackingRate;
                    Combat();
                }
            }
        }

        if (WaveManager.WaveOver && EnemyTargets.Count != 0)
        {
            EnemyTargets.Clear();
        }
    }

    void Combat()
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

    public void GrabTarget()
    {
        if (EnemyTargets[0] != null)
        {
            Vector2 targetpos = EnemyTargets[0].transform.position;
            Direction = targetpos - (Vector2)transform.position;
        }
        else
        {
            print("Caught");
            return;
        }
    }

    public GameObject GetFirstEnemy()
    {
        for (int i = 0; i < EnemyTargets.Count; i++)
        {
            if (EnemyTargets[i] != null)
            {
                Direction = (Vector2)EnemyTargets[i].transform.position - (Vector2)transform.position;
                return EnemyTargets[i];
            }
        }
        return null;
    }

    public override void Upgrade1()
    {
        
        
            AudioSource.PlayClipAtPoint(upgrade, Camera.main.transform.position);
            AttackingRate = 2;
            
            upgrade1.SetActive(true);
        upgrade0.SetActive(false);
        Level = 1;
        
    }
    public override void Upgrade2()
    {
       
        
            AudioSource.PlayClipAtPoint(upgrade, Camera.main.transform.position);
            Damage = 6;
            
            upgrade2.SetActive(true);
            upgrade1.SetActive(false);
        Level = 2;
        
    }
    public override void Upgrade3()
    {
        
        
            AudioSource.PlayClipAtPoint(upgrade, Camera.main.transform.position);
            AttackingRate = 5;
            
            upgrade3.SetActive(true);
            upgrade2.SetActive(false);
        Level = 3;
        
    }
    
}
