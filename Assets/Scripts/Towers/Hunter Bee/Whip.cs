using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Whip : MonoBehaviour
{
    public Transform target;

    //public AudioClip hit;

    private Rigidbody2D rb;

    public float speed = 5f;
    public float rotateSpeed = 9999999f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        HunterBee hb = GameObject.FindObjectOfType<HunterBee>();
        if (collision.gameObject.tag == "Enemy")
        {
            // AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
            collision.GetComponent<EnemyAI>().Damaged(hb.Damage);
        
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }

    }

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        StartCoroutine(Duration());
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(.1f);
        Object.Destroy(this.gameObject);
    }
}
