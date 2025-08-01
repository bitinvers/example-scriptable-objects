using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int quantity;

    public InventorySlot(ItemObject item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}



public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void AddItem(ItemObject item, int quantity = 1)
    {
        if (item == null) return;
        InventorySlot slot = slots.Find(s => s.item == item);
        if (slot != null)
        {
            if (item.maxStack > 0)
            {
                slot.quantity = Mathf.Min(slot.quantity + quantity, item.maxStack);
            }
            else
            {
                slot.quantity += quantity;
            }
        }
        else
        {
            int addAmount = item.maxStack > 0 ? Mathf.Min(quantity, item.maxStack) : quantity;
            InventorySlot newSlot = new InventorySlot(item, addAmount);
            slots.Add(newSlot);
        }

        Debug.Log($"Picked up {item.itemName} (x{quantity}). New count: {GetItemCount(item)}");
        UpdateInventoryUI();
    }

    public int GetItemCount(ItemObject item)
    {
        InventorySlot slot = slots.Find(s => s.item == item);
        return slot != null ? slot.quantity : 0;
    }

    public bool RemoveItem(ItemObject item, int quantity = 1)
    {
        InventorySlot slot = slots.Find(s => s.item == item);
        if (slot == null) return false;
        slot.quantity -= quantity;
        if (slot.quantity <= 0)
        {
            slots.Remove(slot);
        }
        UpdateInventoryUI();
        return true;
    }

    public System.Action OnInventoryChanged;

    private void UpdateInventoryUI()
    {
        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }
}
