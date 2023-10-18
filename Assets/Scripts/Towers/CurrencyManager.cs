using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int startingCurrency = 20;
    private int currentCurrency;

    public TMP_Text currencyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentCurrency = startingCurrency;

        UpdateCurrencyText();   
    }

    public bool CanAfford(int cost)
    {
        // checks if the player can afford the tower price
        return currentCurrency >= cost;
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        UpdateCurrencyText();
    }

    public void DeductCurrency(int amount)
    {
        if (CanAfford(amount))
        {
            // deduct money from the player if they can afford the tower
            currentCurrency -= amount;

            // update currency text after deducting money
            UpdateCurrencyText();
        }
    }

    private void UpdateCurrencyText()
    {
        // updates the TMP text with the current currency balance
        currencyText.text = ": " + currentCurrency.ToString();
    }
}
