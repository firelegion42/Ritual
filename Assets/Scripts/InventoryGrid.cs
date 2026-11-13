using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class InventoryGrid : MonoBehaviour
{
    public const float TileWidth = 32;
    public const float TileHeight = 32;


    InventoryItem[,] _inventoryItemSlot;

    private RectTransform _rectTransform;

    private Vector2 _mouseGridPosition;

    private Vector2Int _tileGridPosition;

    [SerializeField] private int _gridSizeWidth;

    [SerializeField] private int _gridSizeHeight;

    [SerializeField] private UnityEvent<InventoryItem> ItemPlaced;
    [SerializeField] private UnityEvent<InventoryItem> ItemRemoved;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        Init(_gridSizeWidth, _gridSizeHeight);
    }

    private void Init(int width, int height)
    {
        _inventoryItemSlot = new InventoryItem[width, height];
        Vector2 gridSize = new Vector2(width * TileWidth, height * TileHeight);
        _rectTransform.sizeDelta = gridSize;

    }

    public Vector2Int GetTileGridPosition(Vector2Int mousePosition)
    {
        _mouseGridPosition.x = mousePosition.x - _rectTransform.position.x;
        _mouseGridPosition.y = _rectTransform.position.y - mousePosition.y;

        _tileGridPosition.x = (int)(_mouseGridPosition.x / TileWidth);
        _tileGridPosition.y = (int)(_mouseGridPosition.y / TileHeight);

        return _tileGridPosition;
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        if (CheckBounds(x, y, 1, 1) == false)
        {
            return null;
        }

        InventoryItem item = _inventoryItemSlot[x, y];

        if (item == null) return null;

        SetItemSize(item, item.GridPositionX, item.GridPositionY, null);
        ItemRemoved.Invoke(item);

        return item;
    }

    public bool PlaceItem(InventoryItem inventoryItem, int posX, int posY, ref InventoryItem overlapItem)
    {

        if (CheckBounds(posX, posY, inventoryItem.ItemData.sizeWidth, inventoryItem.ItemData.sizeHeight) == false
            || (CheckOverlap(posX, posY, inventoryItem.ItemData.sizeWidth, inventoryItem.ItemData.sizeHeight, ref overlapItem) == false))
        {
            overlapItem = null;
            return false;
        }

        if (overlapItem != null)
        {
            SetItemSize(overlapItem, overlapItem.GridPositionX, overlapItem.GridPositionY, null);
            ItemRemoved.Invoke(overlapItem);
        }


        RectTransform itemRectTransform = inventoryItem.GetComponent<RectTransform>();
        itemRectTransform.SetParent(_rectTransform);


        SetItemSize(inventoryItem, posX, posY, inventoryItem);

        inventoryItem.SetGridPosition(posX, posY);

        Vector2 position = CalculateGridPosition(inventoryItem, posX, posY);
        Debug.Log(position.y);

        itemRectTransform.localPosition = position;

        ItemPlaced.Invoke(inventoryItem);

        return true;
    }

    public Vector2 CalculateGridPosition(InventoryItem inventoryItem, int posX, int posY)
    {
        Vector2 position = new Vector2();
        position.x = posX * TileWidth + TileWidth * inventoryItem.ItemData.sizeWidth / 2;
        position.y = -(posY * TileHeight + TileHeight * inventoryItem.ItemData.sizeHeight / 2);
        return position;
    }

    private bool CheckOverlap(int posX, int posY, int sizeWidth, int sizeHeight, ref InventoryItem overlapItem)
    {
        for (int x = 0; x < sizeWidth; x++)
        {
            for (int y = 0; y < sizeHeight; y++)
            {
                if (_inventoryItemSlot[posX + x, posY + y] != null)
                {
                    if (overlapItem == null)
                    {
                        overlapItem = _inventoryItemSlot[posX + x, posY + y];
                    }
                    else
                    {
                        if (overlapItem != _inventoryItemSlot[posX + x, posY + y])
                        {
                            return false;
                        }                        
                    }
                }
            }         
        }
        return true;
    }

    private void SetItemSize(InventoryItem item, int posX, int posY, InventoryItem value)
    {
        for (int x = 0; x < item.ItemData.sizeWidth; x++)
        {
            for (int y = 0; y < item.ItemData.sizeHeight; y++)
            {
                _inventoryItemSlot[posX + x, posY + y] = value;
            }
        }
    }

  private bool CheckBounds(int posX, int posY, int width, int height)
    {
        if (posX <0 || posY < 0)
        {
            return false;
        }


        if (posX + width > _gridSizeWidth || posY + height > _gridSizeHeight)
        {
            return false;
        }

        return true;
    }
}
