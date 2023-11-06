using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemHandler : MonoBehaviour
{

    public Item item;

    public Button RemoveButton;

    private void Start()
    {
        // Attach the RemoveItem function to the button's click event.
        RemoveButton.onClick.AddListener(RemoveItem);
    }

    public void RemoveItem()
    {
        Debug.Log("Lol1");
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
        InventoryManager.Instance.ListItems();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
