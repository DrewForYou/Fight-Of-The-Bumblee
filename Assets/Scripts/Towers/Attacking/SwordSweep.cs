using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSweep : MonoBehaviour
{
   
    public int Hits=3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WarriorBeeCode wb = GameObject.FindObjectOfType<WarriorBeeCode>();
        if (collision.gameObject.tag == "Enemy")
        {
            
            collision.GetComponent<EnemyAI>().Damaged(wb.Damage);
            if(Hits <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            { 
                --Hits; 
            }
            
        }
    }

    private void Awake()
    {
        StartCoroutine(Duration());
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(.2f);
        Object.Destroy(this.gameObject);
    }

}
