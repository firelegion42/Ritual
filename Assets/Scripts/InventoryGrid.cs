using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    private const float TileWidth = 32;
    private const float TileHeight = 32;


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
        InventoryItem inventoryItem = Instantiate(smallCube).GetComponent<InventoryItem>();
        PlaceItem(inventoryItem, 1, 1);
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

    public void PlaceItem(InventoryItem inventoryItem, int posX, int posY)
    {
        RectTransform itemRectTransform = inventoryItem.GetComponent<RectTransform>();
        itemRectTransform.SetParent(_rectTransform);
        inventoryItemSlot[posX, posY] = inventoryItem;

        Vector2 position = new Vector2();
        position.x = posX * TileWidth + TileWidth / 2;
        position.y = -(posY * TileHeight + TileHeight/ 2);
        Debug.Log(position.y);

        itemRectTransform.localPosition = position;
    }
}
