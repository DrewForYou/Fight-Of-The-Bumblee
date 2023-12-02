using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementFixIAmAngry : MonoBehaviour
{
    public GameObject Tower;
    public CurrencyManager Currency;
    public int Refund; 

    // Start is called before the first frame update
    void Start()
    {
        Currency = FindAnyObjectByType<CurrencyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            Currency.AddCurrency(Refund);
            Destroy(Tower);
        }
    }
}
