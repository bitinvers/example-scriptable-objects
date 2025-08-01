using UnityEngine;

public enum ItemType { Default, Consumable, Equipment, QuestItem }

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType type = ItemType.Default;
    [TextArea]
    public string description;
    public int maxStack = 1;
}
