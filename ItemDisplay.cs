using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image icon;
    public Text displayName;
    public Item item;

    public delegate void ItemDisplayDelegate(Item item);
    public static event ItemDisplayDelegate OnClick;

    public virtual void Start()
    {
        if (item != null)
            Prime(item);
    }
 
    public virtual void Prime(Item item)
    {      
        this.item = item;

        if(item == null)
        {
            if (displayName != null)
                displayName.text = "";
            if (icon != null)
                icon.sprite = null;
            return;
        }

        if(item != null)
        {
            if (displayName != null)
                displayName.text = item.ItemName;

            if (icon != null)
                icon.sprite = item.Icon;
        }       
    }

    public virtual void Click()
    {
        string displayName = "null";
        if (item != null)
            displayName = item.ItemName;

        Debug.Log(displayName + " clicked");
        if(OnClick != null)
        {
            OnClick.Invoke(item);
        }
        else
        {
            Debug.Log("nobody was listening to " + displayName);
        }
    }
}
