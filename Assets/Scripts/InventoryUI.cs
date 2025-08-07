using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySO playerInventory;
    public TMP_Text inventoryText;

    void Start()
    {
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += RefreshUI;
        }
        RefreshUI();
    }

    void OnDestroy()
    {
        if (playerInventory != null)
            playerInventory.OnInventoryChanged -= RefreshUI;
    }

    public void RefreshUI()
    {
        if (inventoryText == null || playerInventory == null) return;
        if (playerInventory.slots.Count == 0)
        {
            inventoryText.text = "Inventory: (empty)";
        }
        else
        {
            string output = "Inventory:\n";
            foreach (var slot in playerInventory.slots)
            {
                output += $"- {slot.item.itemName} x {slot.quantity}\n";
            }
            inventoryText.text = output;
        }
    }
}
