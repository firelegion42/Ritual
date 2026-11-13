using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    [SerializeField] private InventoryManager _inventoryManager;

    [SerializeField] private  TextMeshProUGUI _uiText;

    public ItemData ItemData => _itemData;

    private bool _playerNear;

    private void OnTriggerEnter(Collider other)
    {
        _playerNear = true;
        _uiText.gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        _playerNear = false;
        _uiText.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(_playerNear == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            _inventoryManager.AddItem(_itemData);
            Destroy(gameObject, 0.5f);
        }
    }
}
