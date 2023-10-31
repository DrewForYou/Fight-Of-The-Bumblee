using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public static UpgradeButton Instance;

    public Button Upgrade1;
    public Button Upgrade2;
    public Button Upgrade3;

    public List<Button> UpgradeButtons;

    public GameObject Upgrades;

    public Tower selectedTower;
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

        gameObject.SetActive(false);
    }

    public void SelectedTower(Tower tower)
    {
        selectedTower = tower;

        gameObject.SetActive(true);

        for (int i = 0; i < UpgradeButtons.Count; i++)
        {
            if (i <= selectedTower.Level)
            {
                UpgradeButtons[i].interactable = true;

            }
            else
            {
                UpgradeButtons[i].interactable = false;
            }
            
        }

        // disables upgrade 1 button once player has used it 
        if (selectedTower.Level >= 1)
        {
            UpgradeButtons[0].interactable = false;
        }

        // disables upgrade 2 button once player has used it
        if (selectedTower.Level >= 2)
        {
            UpgradeButtons[1].interactable = false;
        }

        // disables upgrade 3 button once player has used it 
        if (selectedTower.Level >= 3)
        {
            UpgradeButtons[2].interactable = false;
        }
    }
    public void UpgradeButton1()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(5))
        //(ArcherBeeTower.Instance != null && CurrencyManager.instance.CanAfford(5))
        {
            CurrencyManager.instance.DeductCurrency(5);

            selectedTower.Upgrade1();
            Upgrades.SetActive(false);

            //Upgrade1.interactable = false;
           //UpgradeButtons[0].interactable = false;
            
        }
    }

    public void UpgradeButton2()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(10))
     
        {
            CurrencyManager.instance.DeductCurrency(10);

            selectedTower.Upgrade2();
            Upgrades.SetActive(false);
        }
    }

    public void UpgradeButton3()
    {
        if (selectedTower != null && CurrencyManager.instance.CanAfford(13))
      
        {
            CurrencyManager.instance.DeductCurrency(13);

            selectedTower.Upgrade3();
            Upgrades.SetActive(false);
        }
    }

    
}
