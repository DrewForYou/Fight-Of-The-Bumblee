using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public WaveManager WaveManager;

    private InputAction leftClick;
    private InputAction space;
    void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();

        PlayerInputInstance.currentActionMap.Enable();      // turns on action map

        // finds the "LeftClick" action in the current action map
        leftClick = PlayerInputInstance.currentActionMap.FindAction("LeftClick");
        space = PlayerInputInstance.currentActionMap.FindAction("Space");

        leftClick.performed += LeftClick_performed;
        space.performed += Space_performed;
    }

    private void Space_performed(InputAction.CallbackContext obj)
    {
        WaveManager.TempStart = true;
    }

    private void OnDestroy()
    {
        leftClick.performed -= LeftClick_performed;
        space.performed -= Space_performed;
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
