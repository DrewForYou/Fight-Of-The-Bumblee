using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class TowerPlacement : MonoBehaviour
{
    public static TowerPlacement instance;
   
    public TowerTypeSO ActiveTowerType;

    public bool CanPlaceTower = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void PlaceTower(Vector2 position)
    {

        // CanPlaceTower = true;
        // checks if the player can place tower
        
        if (!CanPlaceTower)
        {
            return;
        }
        
        // makes sure player's mouse isn't over a UI object
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (CurrencyManager.instance.CanAfford(ActiveTowerType.TowerPrice))
            {
                RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

                // if the raycast hits a collider with the tag "path" a tower
                // can not be placed here
                if (hit.collider != null && hit.collider.CompareTag("Path"))
                {
                    CanPlaceTower = false;
                    //Debug.Log("Hit object with tag: " + hit.collider.tag);
                    //Debug.Log("can't place tower here");
                }

                // this code makes it so you can't place the towers on top of
                // each other - just make sure to add the tag "tower" 
                if (hit.collider != null && hit.collider.CompareTag("Tower"))
                {
                    CanPlaceTower = false;
                    
                    //Debug.Log("can't place tower here");
                }
                else
                {
                    // instantiates the selected tower type prefab
                    Instantiate(ActiveTowerType.Prefab, position, Quaternion.identity);
                    
                    // deduct the cost of the tower
                    CurrencyManager.instance.DeductCurrency(ActiveTowerType.TowerPrice);
                    
                    // disable tower placement until player clicks another button
                    CanPlaceTower = false;
                    

                    //CanPlaceTower = true;
                    TowerPlacementUI.instance.Deactivate();
                }

            }
        }
    }
  
}
