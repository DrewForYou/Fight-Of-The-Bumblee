using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KunaiBehavior : MonoBehaviour
{
    public Transform target;

    //public AudioClip hit;

    private Rigidbody2D rb;

    public float speed = 5f;
    public float rotateSpeed = 9999999f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NinjaBee nb = GameObject.FindObjectOfType<NinjaBee>();
        if (collision.gameObject.tag == "Enemy")
        {
            // AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
            collision.GetComponent<EnemyAI>().Damaged(nb.Damage);

            Destroy(this.gameObject);

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
        rb = GetComponent<Rigidbody2D>();
    }
}
