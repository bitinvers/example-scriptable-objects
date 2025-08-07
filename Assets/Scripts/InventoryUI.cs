using System;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Object References")]
    public InventorySO playerInventory;
    public GameObject inventoryPanel;
    public Button toggleInventoryButton;
    public Transform contentContainer;
    public GameObject inventorySlotPrefab;

    void Start()
    {
        inventoryPanel.SetActive(false); //inv hidden by default
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += RefreshUI;
        }
        RefreshUI();

        toggleInventoryButton.onClick.AddListener(() => ToggleInvVisibility());
    }

    void OnDestroy()
    {
        if (playerInventory != null)
            playerInventory.OnInventoryChanged -= RefreshUI;
    }

    public void ToggleInvVisibility()
    {
        //toggles inv panel
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }

    public void RefreshUI()
    {
        foreach(Transform t in contentContainer)
        {
            Destroy(t.gameObject);
        }

        foreach(InventorySlot slot in playerInventory.slots)
        {
            GameObject obj = Instantiate(inventorySlotPrefab, contentContainer);
            if(slot.item.icon != null)
            {
                obj.transform.Find("Icon").GetComponent<Image>().sprite = slot.item.icon;
            }
            else
            {
                //disable game object holding icon if no icon is present on SO
                obj.transform.Find("Icon").gameObject.SetActive(false);
            }

            TMP_Text count = obj.GetComponentInChildren<TMP_Text>();
            count.text = slot.quantity.ToString();

            Button but = obj.GetComponent<Button>();
            but.onClick.AddListener(() => OnClickUse(slot.item));
        }
    }

    private void OnClickUse(ItemObject item)
    {
        Debug.Log($"Used item {item.name}");
        playerInventory.RemoveItem(item, 1);
    }
}
