using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using static UnityEditor.Progress;

public class PassiveEffect : MonoBehaviour
{
    private InventoryGrid _inventory;

    [SerializeField] private PlayerMove player;


    [Inject]
    public void Construct(InventoryGrid inventoryGrid)
    {
        _inventory = inventoryGrid;
    }


    public void ApplyEffect(InventoryItem item)
    {
        if (item.ItemData is IPassive effect)
        {
            effect.ApplyEffect(player);
        }
    }

    public void RemoveEffect(InventoryItem item)
    {
        if (item.ItemData is IPassive effect)
        {
            effect.RemoveEffect(player);
        }
    }
}