using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemObject itemData;
    public int quantity = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory == null)
            {
                inventory = other.GetComponentInChildren<Inventory>();
            }
            if (inventory)
            {
                inventory.AddItem(itemData, quantity);
            }
            else
            {
                Debug.LogWarning("Player has no Inventory component!");
            }

            Destroy(gameObject);
        }
    }
}
