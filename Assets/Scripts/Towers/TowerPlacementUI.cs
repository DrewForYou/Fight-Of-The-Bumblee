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

        bool isPlacementValid = CanPlace();

        if (isPlacementValid)
        {
           spriteRenderer.color = Color.white;
        }
        else
        {
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
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;
    }

    private bool CanPlace()
    {
        
        if (!TowerPlacement.instance.CanPlaceTower)
        {
            //return false;
            //return true;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tower"))
            {
                return false;
            }
        }

        return true;
    }
}
