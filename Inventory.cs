using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public InventoryDisplay inventoryDisplayPrefab;
    public InventoryDisplay display;

    public delegate void InventoryDelegate(Inventory inventory);
    public static event InventoryDelegate OnChange;

    public void Display()
    {
        display = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
        display.Prime(this);            
    }
    public void Hide()
    {             
       Destroy(display.gameObject);  
    }
    
    public bool Add(Item item)
    {  
        if(OnChange != null && item != null)
        {
            items.Add(item);
            OnChange.Invoke(this);            
        }
        return true;
    }
    public bool Remove(Item item)
    {
        if (items.Remove(item) && item != null)
        {
            OnChange.Invoke(this);
            return true;
        }
        return false;       
    }      
}
