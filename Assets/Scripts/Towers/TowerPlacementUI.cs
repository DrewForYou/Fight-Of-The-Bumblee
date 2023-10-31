using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TowerPlacementUI : MonoBehaviour
{
    public static TowerPlacementUI instance;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        FollowMouse();

        // checks if you can place the tower
        bool isPlacementValid = CanPlace();

        if (isPlacementValid)
        {
            // makes ui color white if an object can be placed on something
           spriteRenderer.color = Color.white;
        }
        else
        {
            // makes the ui color red when the sprite is over something it cannot
            // be placed on 
            spriteRenderer.color = Color.red;
        }
        /*
        if (spriteRenderer.enabled)
        {
            FollowMouse();
        }
        */
    }
    private void FollowMouse()
    {
        // code to get the mouse position, makes it so sprite will follow mouse
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite)
    {
        // sets the sprite to the tower that was chosen 
        spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }

    public void Deactivate()
    {
        // disables the sprite 
        spriteRenderer.enabled = false;
    }


    private bool CanPlace()
    {
       // cannot place over ui elements 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        bool canPlace = true;

        // cannot place when over something with the tag tower
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tower"))
            {
               // return false;
               canPlace = false;
            }
        }

        return canPlace;
        //return true;
    }
    
}
