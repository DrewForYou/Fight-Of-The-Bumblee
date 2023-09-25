using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public static TowerPlacement instance;

    public TowerTypeSO activeTowerType;

    public bool canPlaceTower = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaceTower(Vector2 position)
    {
        // checks if the player can place tower
        if (!canPlaceTower)
        {
            return;
        }

        // makes sure player's mouse isn't over a UI object
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (CurrencyManager.instance.CanAfford(activeTowerType.TowerPrice))
            {
                // instantiates the selected tower type prefab
                Instantiate(activeTowerType.prefab, position, Quaternion.identity);

                // deduct the cost of the tower
                CurrencyManager.instance.DeductCurrency(activeTowerType.TowerPrice);
            }

            else
            {
                Debug.Log("Not enough money for tower");
            }
        }
    }
}
