using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PassiveEffect : MonoBehaviour
{
    [SerializeField] private InventoryGrid inventory;

    [SerializeField] private PlayerMove player;


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