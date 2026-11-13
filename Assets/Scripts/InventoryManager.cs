using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager: MonoBehaviour
{
  public InventoryGrid InventoryGrid { get; set; }

    [SerializeField] private InventoryGrid _mainGrid;

   private InventoryItem _selectedItem;
   private  InventoryItem _overlapItem;
   private RectTransform _itemRectTransform;


    [SerializeField] private List<ItemData> _items;

    [SerializeField] private GameObject _itemPrefab;

    [SerializeField] private Transform _uiPanelTransform; 


    private Vector2Int _currentMouse;

    private void Update()
    {
        StickToMouse();

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            CreateRandom();
        }


        if (InventoryGrid != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            GrabItem();
        }
    }

    private void CreateRandom()
    {
        InventoryItem inventoryItem = Instantiate(_itemPrefab).GetComponent<InventoryItem>();
        _selectedItem = inventoryItem;
        _itemRectTransform = inventoryItem.GetComponent<RectTransform>();
        _itemRectTransform.SetParent(_uiPanelTransform);


        inventoryItem.Set(_items[Random.Range(0, _items.Count)]);       
    }

    private void StickToMouse()
    {
        if (_selectedItem != null)
        {
            _itemRectTransform.position = Mouse.current.position.ReadValue();
        }
    }

    private void GrabItem()
    {
        _currentMouse = InventoryGrid.GetTileGridPosition(Vector2Int.FloorToInt(Mouse.current.position.ReadValue()));

        if (_selectedItem == null)
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
        _selectedItem = InventoryGrid.PickUpItem(_currentMouse.x, _currentMouse.y);

        if(_selectedItem != null)
        {
            _itemRectTransform = _selectedItem.GetComponent<RectTransform>();
        }
        
    }

    private void PlaceItem()
    {
       bool complete = InventoryGrid.PlaceItem(_selectedItem, _currentMouse.x, _currentMouse.y, ref _overlapItem);
        if (complete)
        {
            _selectedItem = null;
            if(_overlapItem != null)
            {
                _selectedItem = _overlapItem;
                _overlapItem = null;
                _itemRectTransform = _selectedItem.GetComponent<RectTransform>();
            }
        }

        
    }

    public void AddItem(ItemData itemData)
    {
        Debug.Log($"grid: {_mainGrid}, prefab: {_itemPrefab}, data: {itemData}");
        InventoryItem item = Instantiate(_itemPrefab).GetComponent<InventoryItem>();
        item.Set(itemData);
      _mainGrid.PlaceItem(item, 1, 1, ref _overlapItem);
    }
}
