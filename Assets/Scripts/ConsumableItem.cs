using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Inventory/Item (Consumable)")]
public class ConsumableItem : ItemObject
{
    public int healAmount;
    public bool isStackable = true;

    private void OnEnable()
    {
        type = ItemType.Consumable;
        if (maxStack < 2 && isStackable)
        {
            maxStack = 10;
        }
    }
}
