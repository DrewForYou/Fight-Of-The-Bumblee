using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public static UpgradeButton Instance;

    public Button Upgrade1;
    public Button Upgrade2;
    public Button Upgrade3;

    public GameObject Upgrades;

    private Tower selectedTower;
   
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Upgrade1.onClick.AddListener(UpgradeButton1);
        Upgrade2.onClick.AddListener(UpgradeButton2);
        Upgrade3.onClick.AddListener(UpgradeButton3);

        Upgrade2.interactable = false;
        Upgrade3.interactable = false;
    }

    public void SelectedTower(Tower tower)
    {
        selectedTower = tower;  
    }
    public void UpgradeButton1()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(5))
        //(ArcherBeeTower.Instance != null && CurrencyManager.instance.CanAfford(5))
        {
            CurrencyManager.instance.DeductCurrency(5);

            selectedTower.Upgrade1();
            Upgrades.SetActive(false);
            Upgrade1.interactable = false;
            Upgrade2.interactable = true;
            
        }
    }

    public void UpgradeButton2()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(10))
     
        {
            CurrencyManager.instance.DeductCurrency(10);

            selectedTower.Upgrade2();
            Upgrades.SetActive(false);
            Upgrade2.interactable = false;
            Upgrade3.interactable = true;
        }
    }

    public void UpgradeButton3()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(13))
      
        {
            CurrencyManager.instance.DeductCurrency(13);

            selectedTower.Upgrade3();
            Upgrades.SetActive(false);
            Upgrade3.interactable= false;
        }
    }
  
}
