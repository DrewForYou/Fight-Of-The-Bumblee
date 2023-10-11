using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBeeFreeze : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<EnemyAI>().Frozen == false)
            {
                collision.gameObject.GetComponent<EnemyAI>().Speed /= 2;
                collision.gameObject.GetComponent<EnemyAI>().Frozen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<EnemyAI>().Frozen == true)
            {
                collision.gameObject.GetComponent<EnemyAI>().Frozen = false;
                collision.gameObject.GetComponent<EnemyAI>().Speed *= 2;
            }
        }
    }

}
