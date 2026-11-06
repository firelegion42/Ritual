using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public const float TileWidth = 32;
    public const float TileHeight = 32;


    InventoryItem[,] inventoryItemSlot;

    private RectTransform _rectTransform;

    private Vector2 _mouseGridPosition;

    private Vector2Int _tileGridPosition;

    [SerializeField] private int gridSizeWidth;

    [SerializeField] private int gridSizeHeight;

    [SerializeField] private GameObject smallCube;



    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        Init(gridSizeWidth, gridSizeHeight);
    }

    private void Init(int width, int height)
    {
        inventoryItemSlot = new InventoryItem[width, height];
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
        InventoryItem item = inventoryItemSlot[x, y];

        if (item == null) return null;

        SetItemSize(item, item.GridPositionX, item.GridPositionY, null);
        
        return item;
    }

    public void PlaceItem(InventoryItem inventoryItem, int posX, int posY)
    {

        if (CheckBounds(posX, posY) == false)
        {
            return;
        }

        RectTransform itemRectTransform = inventoryItem.GetComponent<RectTransform>();
        itemRectTransform.SetParent(_rectTransform);


        SetItemSize(inventoryItem, posX, posY, inventoryItem);

        inventoryItem.SetGridPosition(posX, posY);

        Vector2 position = new Vector2();
        position.x = posX * TileWidth + TileWidth * inventoryItem.ItemData.sizeWidth / 2;
        position.y = -(posY * TileHeight + TileHeight * inventoryItem.ItemData.sizeHeight / 2);
        Debug.Log(position.y);

        itemRectTransform.localPosition = position;
    }

    private void SetItemSize(InventoryItem item, int posX, int posY, InventoryItem value)
    {
        for (int x = 0; x < item.ItemData.sizeWidth; x++)
        {
            for (int y = 0; y < item.ItemData.sizeHeight; y++)
            {
                inventoryItemSlot[posX + x, posY + y] = item;
            }
        }
    }

  private bool CheckBounds(int posX, int posY)
    {
        if (posX <0 || posY < 0)
        {
            return false;
        }


        if (posX > gridSizeWidth || posY > gridSizeHeight)
        {
            return false;
        }

        return true;
    }
}
