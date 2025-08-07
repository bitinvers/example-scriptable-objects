using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Inventory/Item (Consumable)")]
public class ConsumableItem : ItemObject
{
    public int healAmount;
    public bool isStackable = true;

    internal void Use()
    {
        //put use code here
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        type = ItemType.Consumable;
        if (maxStack < 2 && isStackable)
        {
            maxStack = 10;
        }
    }
}
