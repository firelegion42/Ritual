using UnityEngine;
using UnityEngine.EventSystems;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryGrid _selectedGrid;
    [SerializeField] private InventoryManager _inventoryManager;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
        _inventoryManager.InventoryGrid = _selectedGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _inventoryManager.InventoryGrid = null;
    }
}
