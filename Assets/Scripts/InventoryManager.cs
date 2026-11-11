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
    InventoryItem overlapItem;
    RectTransform itemRectTransform;


    [SerializeField] List<ItemData> items;

    [SerializeField] ItemData ammoData;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Transform uiPanelTransform; 


    private Vector2Int currentMouse;

    private void Update()
    {
        StickToMouse();

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            CreateRandom();
        }


        if (inventoryGrid != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            GrabItem();
        }
    }

    private void CreateRandom()
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;
        itemRectTransform = inventoryItem.GetComponent<RectTransform>();
        itemRectTransform.SetParent(uiPanelTransform);


        inventoryItem.Set(items[Random.Range(0, items.Count)]);       
    }

    private void StickToMouse()
    {
        if (selectedItem != null)
        {
            itemRectTransform.position = Mouse.current.position.ReadValue();
        }
    }

    private void GrabItem()
    {
        currentMouse = inventoryGrid.GetTileGridPosition(Vector2Int.FloorToInt(Mouse.current.position.ReadValue()));

        if (selectedItem == null)
        {
            PickUpItem();
        }
        else
        {
            PlaceItem();
        }
    }

    private void PickUpItem()
    {
        selectedItem = inventoryGrid.PickUpItem(currentMouse.x, currentMouse.y);

        if(selectedItem != null)
        {
            itemRectTransform = selectedItem.GetComponent<RectTransform>();
        }
        
    }

    private void PlaceItem()
    {
       bool complete = inventoryGrid.PlaceItem(selectedItem, currentMouse.x, currentMouse.y, ref overlapItem);
        if (complete)
        {
            selectedItem = null;
            if(overlapItem != null)
            {
                selectedItem = overlapItem;
                overlapItem = null;
                itemRectTransform = selectedItem.GetComponent<RectTransform>();
            }
        }

        
    }

    public void AddItem()
    {
       InventoryItem ammo = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        ammo.Set(ammoData);
      //  inventoryGrid.PlaceItem(ammo, 1, 1);
    }
}
