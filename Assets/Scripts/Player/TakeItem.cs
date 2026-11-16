using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class TakeItem : MonoBehaviour
{
    private InventoryManager _inventoryManager;

    [SerializeField] private TextMeshProUGUI _hintText;

    public InventoryManager Inventory => _inventoryManager;

    private ITakeable _currentItem;


    [Inject]
    public void Construct(InventoryManager inventoryManager)
    {
        _inventoryManager = inventoryManager;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITakeable takeable))
        {
            _currentItem = takeable;
            _hintText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ClearItem();
    }

    private void Update()
    {
        if (_currentItem != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentItem.Interact(this);
            ClearItem();
        }
    }

    private void ClearItem()
    {
        _currentItem = null;
        _hintText.gameObject.SetActive(false);
    }
}
