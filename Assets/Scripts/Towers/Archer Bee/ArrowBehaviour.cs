using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowBehaviour : MonoBehaviour
{
    public Transform target;

    //public int Hits = 3;
    //public AudioClip hit;

    private Rigidbody2D rb;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReworkedArcherBee ab = GameObject.FindObjectOfType<ReworkedArcherBee>();
        if (collision.gameObject.tag == "Enemy")
        {
            // AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
            collision.GetComponent<EnemyAI>().Damaged(ab.Damage);
            
                Destroy(this.gameObject);          

        }
    }

    private void FixedUpdate()
    {
       if(target != null)
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
        // StartCoroutine(Duration());
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody2D>();
    }

   /*
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(.2f);
        Object.Destroy(this.gameObject);
    }
   */
}
