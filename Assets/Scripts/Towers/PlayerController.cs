using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;

    private InputAction leftClick;
    void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();

        PlayerInputInstance.currentActionMap.Enable();      // turns on action map

        // finds the "LeftClick" action in the current action map
        leftClick = PlayerInputInstance.currentActionMap.FindAction("LeftClick");

        leftClick.performed += LeftClick_performed;
    }

    private void OnDestroy()
    {
        leftClick.performed -= LeftClick_performed;
    }

    public void LeftClick_performed(InputAction.CallbackContext obj)
    {
        // finds the position of the player's mouse 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // instantiate the tower at the player's mouse position
        TowerPlacement.instance.PlaceTower(mousePosition);

        Debug.Log("Player Clicked");        // let's us know the player is able
                                            // to click
    }
}
