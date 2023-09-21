using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public TowerTypeSO towerType;
    
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectTower);
    }

    private void SelectTower()
    {
        // instantiates the selected tower type
        TowerPlacement.instance.activeTowerType = towerType;

        // enables tower placement when button is selected
        TowerPlacement.instance.canPlaceTower = true;
    }
}
