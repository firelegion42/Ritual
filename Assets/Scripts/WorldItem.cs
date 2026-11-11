using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private  TextMeshProUGUI _UItext;

    public ItemData ItemData => _itemData;

    private bool playerNear;

    private void OnTriggerEnter(Collider other)
    {
        playerNear = true;
        _UItext.gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        playerNear = false;
        _UItext.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(playerNear == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            inventoryManager.AddItem();
        }
    }
}
