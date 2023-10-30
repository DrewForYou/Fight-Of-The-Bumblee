using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Selling : MonoBehaviour
{
    public CurrencyManager CurrencyManager;
    public int SellPrice;

    private void Start()
    {
        CurrencyManager = FindAnyObjectByType<CurrencyManager>();
    }

    public void Sell()
    {
        CurrencyManager.AddCurrency(SellPrice);
        Object.Destroy(this.gameObject);
    }
}
