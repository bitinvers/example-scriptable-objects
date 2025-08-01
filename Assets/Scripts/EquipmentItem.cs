using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipment", menuName = "Inventory/Item (Equipment)")]
public class EquipmentItem : ItemObject
{
    public int attackPower;
    public int defenseValue;

    private void OnEnable()
    {
        type = ItemType.Equipment;
        maxStack = 1;
    }
}
