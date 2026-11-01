using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    private const float TileWidth = 32;
    private const float TileHeight = 32;

    private RectTransform _rectTransform;

    private Vector2 _mouseGridPosition;

    private Vector2Int _tileGridPosition;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public Vector2Int GetTileGridPosition(Vector2Int mousePosition)
    {
        _mouseGridPosition.x = mousePosition.x - _rectTransform.position.x;
        _mouseGridPosition.y = _rectTransform.position.y - mousePosition.y;

        _tileGridPosition.x = (int)(_mouseGridPosition.x / TileWidth);
        _tileGridPosition.y = (int)(_mouseGridPosition.y / TileHeight);

        return _tileGridPosition;
    }
}
