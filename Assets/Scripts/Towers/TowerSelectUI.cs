using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public TowerTypeSO TowerType;

    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        //Button button = GetComponent<Button>();
        
        button.onClick.AddListener(SelectTower);
        
        //CanAffordButton();
    }
    /*
    public void CanAffordButton()
    {
        bool canAfford = (CurrencyManager.instance.CanAfford(TowerType.TowerPrice));
        button.interactable = canAfford;
        button.interactable = false;

        if (!canAfford)
        {
            button.interactable = true;
        }
    }
    */
    private void SelectTower()
    {
        if (CurrencyManager.instance.CanAfford(TowerType.TowerPrice))
        {
            // instantiates the selected tower type
            TowerPlacement.instance.ActiveTowerType = TowerType;

            // enables tower placement when button is selected
            TowerPlacement.instance.CanPlaceTower = true;

            
        }  
    }


}
