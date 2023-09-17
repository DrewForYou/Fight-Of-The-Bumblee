using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public GameObject[] Towers;
    private GameObject pendingTower;

    private Vector2 pos;

    private RaycastHit hit;
    public LayerMask layerMask;

    /*
    private void Update()
    {
        if(pendingTower != null)
        {
            pendingTower.transform.position = pos;

            if (MouseButton.current.leftButton.wasPressedThisFrame)
            {
                PlaceObject();
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(MouseButton.current.position.
            ReadValue());

        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            pos = hit.point;
        }
    }
    public void SelectTower(int index)
    {
        pendingTower = Instantiate(Towers[index]);
    }

    public void PlaceObject()
    {
        pendingTower = null;
    }
    */
}
