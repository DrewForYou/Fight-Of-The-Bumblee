using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBeeLightning : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyAI>().Damaged(Damage);
            Destroy(this.gameObject);
        }
    }
}
