using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBeeFireball : MonoBehaviour
{
    public int Damage;
    public Rigidbody2D Rigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().SetBool("HitEnemy", true);
            Rigidbody.velocity = Vector3.zero;
            collision.GetComponent<EnemyAI>().Damaged(Damage);
        }
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
