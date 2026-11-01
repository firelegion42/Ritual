using UnityEngine;
using UnityEngine.EventSystems;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryGrid selectedGrid;
    [SerializeField] private InventoryManager inventoryManager;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryManager.InventoryGrid = selectedGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryManager.InventoryGrid = null;
    }
}
