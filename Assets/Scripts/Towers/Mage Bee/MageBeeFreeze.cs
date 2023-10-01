using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBeeFreeze : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().Speed /= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().Speed *= 2;
        }
    }

}
