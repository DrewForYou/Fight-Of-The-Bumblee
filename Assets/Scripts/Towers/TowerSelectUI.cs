using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public TowerTypeSO TowerType;
    
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectTower);
    }

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
