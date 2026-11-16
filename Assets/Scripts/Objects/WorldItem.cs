using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour, ITakeable
{
    [SerializeField] private ItemData _itemData;


    public void Interact(TakeItem player)
    {
        player.Inventory.AddItem(_itemData);
        Destroy(gameObject);
    }
}
