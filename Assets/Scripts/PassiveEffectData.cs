using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveEffectData", menuName = "Scriptable Objects/PassiveEffectData")]
public class PassiveEffectData : ItemData, IPassive
{
    [SerializeField] private float _movementSpeedBonus;

    public void ApplyEffect(PlayerMove player)
    {
        player.ModifySpeed(_movementSpeedBonus);
    }

    public void RemoveEffect(PlayerMove player)
    {
        player.ModifySpeed(-_movementSpeedBonus);
    }
}
