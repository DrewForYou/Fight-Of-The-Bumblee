using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public WaveManager WaveManager;
 
    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction space;

    public GameObject Upgrades;
    //private ArcherBeeTower selectedTower;
    void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();

        PlayerInputInstance.currentActionMap.Enable();      // turns on action map

        // finds the "LeftClick" action in the current action map
        leftClick = PlayerInputInstance.currentActionMap.FindAction("LeftClick");
        rightClick = PlayerInputInstance.currentActionMap.FindAction("RightClick");
        space = PlayerInputInstance.currentActionMap.FindAction("Space");

        leftClick.performed += LeftClick_performed;
        rightClick.performed += RightClick_performed;
        space.performed += Space_performed;
    }

    private void Space_performed(InputAction.CallbackContext obj)
    {
        WaveManager.TempStart = true;
    }

    private void OnDestroy()
    {
        leftClick.performed -= LeftClick_performed;
        rightClick.performed -= RightClick_performed;
        space.performed -= Space_performed;
    }

    public void RightClick_performed(InputAction.CallbackContext obj)
    {
        // detect tower the player is clicking
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            //selectedTower = hit.collider.GetComponent<ArcherBeeTower>();
            ArcherBeeTower tower = hit.collider.GetComponent<ArcherBeeTower>();
            //MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();
            
            if (tower != null)
            {
                Upgrades.SetActive(true);
                UpgradeButton.Instance.SelectedTower(tower);
                /*
                if (CurrencyManager.instance.CanAfford(5))
                {
                    CurrencyManager.instance.DeductCurrency(5);

                    tower.Upgrade1();
                }
                */
            }

        }
        /*
        else 
        {
            MageBeeCode tower = hit.collider.GetComponent<MageBeeCode>();

            if (tower != null)
            {
                Upgrades.SetActive(true);
                if (CurrencyManager.instance.CanAfford(5))
                {
                    CurrencyManager.instance.DeductCurrency(5);

                    tower.Upgrade1();
                }

            }
        }
        */

    }
    public void LeftClick_performed(InputAction.CallbackContext obj)
    {
        // finds the position of the player's mouse 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // this code makes it so the tower will snap to the grid - tower will be placed inside
        // the closest grid player is clicking on. without the + 0.5f & -0.5f the towers
        // instantiate on the middle lines of the grid - not in the middle of the grid square
        mousePosition.x = Mathf.Round(mousePosition.x + 0.5f) - 0.5f;
        mousePosition.y = Mathf.Round(mousePosition.y + 0.5f) - 0.5f;
        
        // instantiate the tower at the player's mouse position
        TowerPlacement.instance.PlaceTower(mousePosition);
        
        //Debug.Log("Player Clicked");        // let's us know the player is able
                                            // to click
    }
}
