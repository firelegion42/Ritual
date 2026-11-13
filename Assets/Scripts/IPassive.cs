using UnityEngine;

public interface IPassive
{
    void ApplyEffect(PlayerMove player);

    void RemoveEffect(PlayerMove player);
}
