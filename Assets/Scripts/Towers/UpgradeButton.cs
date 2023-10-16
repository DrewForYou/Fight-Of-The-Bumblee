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
            //ArcherBeeTower.Instance.Upgrade1();
        }
    }

    public void UpgradeButton2()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(10))
     
        {
            CurrencyManager.instance.DeductCurrency(10);

            selectedTower.Upgrade2();
           
        }
    }

    public void UpgradeButton3()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(13))
      
        {
            CurrencyManager.instance.DeductCurrency(13);

            selectedTower.Upgrade3();
            
        }
    }
    /*
    public TowerTypeSO tower;
    public int Upgrade1Cost = 5;
    public Button button;
    private bool isUpgrade1Purchased = false;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UpgradeButton1);
    }

    private void UpgradeButtonState()
    {
        bool canAffordUpgrade1 = !isUpgrade1Purchased && CurrencyManager.instance.CanAfford(Upgrade1Cost);
    }
    public void UpgradeButton1()
    {
        if (!isUpgrade1Purchased && CurrencyManager.instance.CanAfford(Upgrade1Cost))
        {
            CurrencyManager.instance.DeductCurrency(Upgrade1Cost);
            //tower.Upgrade1();
            isUpgrade1Purchased=true;

        }
        
    }
    */
}
