using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TMP_Text TowerText;
    public TMP_Text UpgradeText1;
    public TMP_Text UpgradeText2;
    public TMP_Text UpgradeText3;
    //public GameObject SniperBeeUpgrades;
   // public GameObject MageBeeUpgrades;

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
        //Debug.Log("Selected Tower: " + selectedTower.towerName);
        //UpdateTowerText();
    }
    public void SelectedTower(Tower tower)
    {
        selectedTower = tower;
        //UpdateTowerText(selectedTower.towerName);
        UpdateTowerText();
        Debug.Log("Selected Tower: " + selectedTower.towerName);
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

    private void UpdateTowerText()
    {
        if (selectedTower != null)
        {
            TowerText.text = selectedTower.towerName;
            if (selectedTower is SniperBee)
            {
                UpgradeText1.text = ((SniperBee)selectedTower).Upgrade1Text;
                UpgradeText2.text = ((SniperBee)selectedTower).Upgrade2Text;
                UpgradeText3.text = ((SniperBee)selectedTower).Upgrade3Text;
            }
            if (selectedTower is MageBeeCode)
            {
                UpgradeText1.text = ((MageBeeCode)selectedTower).Upgrade1Text;
                UpgradeText2.text = ((MageBeeCode)selectedTower).Upgrade2Text;
                UpgradeText3.text = ((MageBeeCode)selectedTower).Upgrade3Text;
            }
        }
    }   
}
