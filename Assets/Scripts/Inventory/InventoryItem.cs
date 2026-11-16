using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
   public ItemData ItemData { get; private set; }
    public int GridPositionX { get; private set; }

    public int GridPositionY { get; private set; }

    [SerializeField] private TextMeshProUGUI _itemCountText;
    public void Set(ItemData itemData)
    {
        ItemData = itemData;

        GetComponent<Image>().sprite = itemData.sprite;
        

        Vector2 size = new Vector2();
        size.x = itemData.sizeWidth * InventoryGrid.TileWidth;
        size.y = itemData.sizeHeight * InventoryGrid.TileHeight;
        GetComponent<RectTransform>().sizeDelta = size;
    }

    public void SetGridPosition(int x, int y)
    {
        GridPositionX = x;

        GridPositionY = y;
    }
}
