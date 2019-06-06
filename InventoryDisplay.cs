using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public Transform targetTransform;
    public ItemDisplay itemDisplayPrefab;
    public Inventory inventory;

    private void Start()
    {
        Inventory.OnChange += Inventory_OnChange;      
    }
    private void OnDestroy()
    {
        Inventory.OnChange -= Inventory_OnChange;     
    }
    private void Inventory_OnChange(Inventory inventory)
    {
        if(this.inventory = inventory)
        {
            Prime(inventory);
        }        
    }

    public void Prime(Inventory inventory)
    {
        for (int i = 0; i < targetTransform.childCount; i++)
        {
            Destroy(targetTransform.GetChild(i).gameObject);
        }
        this.inventory = inventory;
        List<Item> items = inventory.items;
        foreach (Item item in items)
        {
            ItemDisplay display = (ItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform);
            display.Prime(item);
        }
    }
}
