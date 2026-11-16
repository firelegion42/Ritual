using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryGrid _selectedGrid;
    private InventoryManager _inventoryManager;

    [Inject]
    public void Construct(InventoryManager inventoryManager)
    {
        _inventoryManager = inventoryManager;     
    }
    

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
