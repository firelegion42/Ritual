using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager: MonoBehaviour
{
    private InventoryGrid inventoryGrid;

    public InventoryGrid InventoryGrid
    {
        get => inventoryGrid;

        set => inventoryGrid = value;
    }

    private Vector2Int currentMouse;

    private void Update()
    {
        if (inventoryGrid != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
           currentMouse = inventoryGrid.GetTileGridPosition(Vector2Int.FloorToInt(Mouse.current.position.ReadValue()));
            Debug.Log(currentMouse);

        }
    }

}
