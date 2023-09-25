using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public WaveManager WaveManager;

    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction space;
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
            testingTower2 tower = hit.collider.GetComponent<testingTower2>();

            if (tower != null)
            {
                if (CurrencyManager.instance.CanAfford(5))
                {
                    CurrencyManager.instance.DeductCurrency(5);

                    tower.Upgrade1();
                }
            }
        }
    }
    public void LeftClick_performed(InputAction.CallbackContext obj)
    {
        // finds the position of the player's mouse 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Debug.Log(mousePosition);

        // instantiate the tower at the player's mouse position
        TowerPlacement.instance.PlaceTower(mousePosition);

        Debug.Log("Player Clicked");        // let's us know the player is able
                                            // to click
    }
}
