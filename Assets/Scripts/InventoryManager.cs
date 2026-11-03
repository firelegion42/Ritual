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

    InventoryItem selectedItem;

    private Vector2Int currentMouse;

    private void Update()
    {
    //    if (inventoryGrid != null && Mouse.current.leftButton.wasPressedThisFrame)
    //    {
    //       currentMouse = inventoryGrid.GetTileGridPosition(Vector2Int.FloorToInt(Mouse.current.position.ReadValue()));
            
    //        if(selectedItem == null)
    //        {
    //            selectedItem = inventoryGrid.PickUpItem(_tileGridPosition.x, _tileGridPosition.y);
    //        }
    //        else
    //        {
    //            inventoryGrid.PlaceItem(selectedItem, _tileGridPosition.x, _tileGridPosition.y);
    //        }
    //    }
    }

}
