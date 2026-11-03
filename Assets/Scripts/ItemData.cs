using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{

    public string itemName;
    public int sizeWidth;

    public int sizeHeight;

    public Sprite sprite;
}
