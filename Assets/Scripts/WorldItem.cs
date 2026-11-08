using UnityEngine;
using UnityEngine.InputSystem;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private InventoryGrid inventoryGrid;

    public ItemData ItemData => _itemData;

    private bool playerNear;

    private void OnCollisionEnter(Collision collision)
    {
        playerNear = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        playerNear = false;
    }

    private void Update()
    {
        if(playerNear == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            InventoryManager.AddItem();
        }
    }
}
