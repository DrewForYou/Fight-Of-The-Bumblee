using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBeeBaseAttack : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
