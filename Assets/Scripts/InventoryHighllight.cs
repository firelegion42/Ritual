using UnityEngine;

public class InventoryHighllight : MonoBehaviour
{
    [SerializeField] private RectTransform highlight;

    public void SetSize(InventoryItem item)
    {
        Vector2 itemSize = new Vector2();
        itemSize.x = item.ItemData.sizeWidth * InventoryGrid.TileWidth;
        itemSize.y = item.ItemData.sizeHeight * InventoryGrid.TileHeight;
        highlight.sizeDelta = itemSize;
    }



    public void SetPosition(InventoryGrid inventory, InventoryItem item)
    {
        highlight.SetParent(inventory.GetComponent<RectTransform>());

        Vector2 position = inventory.CalculateGridPosition(item, item.GridPositionX, item.GridPositionY);


    }
}
