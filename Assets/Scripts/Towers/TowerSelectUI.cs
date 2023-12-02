using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public TowerTypeSO TowerType;
    
    
    private Button button;
    private bool buttonPressed = false;
 
  
    private void Start()
    {
        button = GetComponent<Button>();
        //Button button = GetComponent<Button>();
        
        button.onClick.AddListener(SelectTower);
        button.interactable = !buttonPressed;
        //isPreviewingTower = false;
        
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

            Sprite towerSprite = TowerType.TowerSprite;

            if (towerSprite != null)
            {
                TowerPlacementUI.instance.Activate(towerSprite);
            }
            else
            {
                //Debug.Log("No sprite renderer found");
            }
        }  
    }

    // code for queen bee only being allowed to place once
    public void QueenBeeButton()
    {
        if (!buttonPressed && CurrencyManager.instance.CanAfford(TowerType.TowerPrice))
        {
            buttonPressed = true;
            
            // enables tower placement when button is selected
            TowerPlacement.instance.CanPlaceTower = true;

            Sprite towerSprite = TowerType.TowerSprite;

            if (towerSprite != null)
            {
                TowerPlacementUI.instance.Activate(towerSprite);
                button.interactable = false;
            }
            
            if(FindAnyObjectByType<QueenBeeCode>() == null)
            {
                button.interactable = true;
            }

            else
            {
                //Debug.Log("No sprite renderer found");
            }
        }
    }

    

}
