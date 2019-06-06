using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public EquipableItem helmet,
        chest,
        gloves,
        boots,
        weapon,
        accessory;

    public Stat Strenght;
    public Stat Agility;
    public Stat Intelligence;
    public Stat Vitality;

    [SerializeField] StatPanel statPanel;
    public Inventory inventory;
    public EquipmentDisplay equipmentPanel;

    public delegate void HeroDelegate(Hero hero);
    public static event HeroDelegate OnChange;

    private void Awake()
    {
        /*statPanel.SetStats(Strenght, Agility, Intelligence, Vitality);
        statPanel.UpdateStatValues();*/

        inventory = gameObject.GetComponent<Inventory>();
    }
    private void OnGUI()
    {
        //TO SEE IF IT WORK
        GUI.Label(new Rect(10, 10, 100, 20), Strenght.Value.ToString());
        GUI.Label(new Rect(10, 40, 100, 20), Agility.Value.ToString());
        GUI.Label(new Rect(10, 70, 100, 20), Intelligence.Value.ToString());
        GUI.Label(new Rect(10, 100, 100, 20), Vitality.Value.ToString());
    }

    public bool IsEquipped(EquipableItem item)
    {
        if (helmet == item)
            return true;
        if (chest == item)
            return true;
        if (boots == item)
            return true;
        if (gloves == item)
            return true;
        if (weapon == item)
            return true;
        if (accessory == item)
            return true;

        return false;
    }
    public void Dequip(EquipableItem item)
    {
        if (helmet == item)
            helmet = null;
        if (chest == item)
            chest = null;
        if (gloves == item)
            gloves = null;
        if (boots == item)
            boots = null;
        if (weapon == item)
            weapon = null;
        if (accessory == item)
            accessory = null;

        if (OnChange != null)
        {
            Debug.Log("hero equipment changed");
            OnChange.Invoke(this);
        }
    }
    public bool Equip(EquipableItem item)
    {
        if (item == null)
            return false;

        switch(item.type)
        {
            default:
                Debug.Log("Hero doesnt know how to equip that");
                return false;
            case EquipmentType.Accesorry:
                this.inventory.Add(accessory);
                accessory = item;
                accessory.Equip(this);
                break;
            case EquipmentType.Boots:
                this.inventory.Add(boots);
                boots = item;
                boots.Equip(this);
                break;                
            case EquipmentType.Chest:
                this.inventory.Add(chest);
                chest = item;
                chest.Equip(this);
                break;
            case EquipmentType.Glove:
                this.inventory.Add(gloves);
                gloves = item;
                gloves.Equip(this);
                break;
            case EquipmentType.Helmet:
                this.inventory.Add(helmet);
                helmet = item;
                helmet.Equip(this);
                break;
            case EquipmentType.Weapon:
                this.inventory.Add(weapon);
                weapon = item;
                weapon.Equip(this);
                break;   
        }
        if(OnChange != null)
        {
            Debug.Log("hero equipment changed");
            OnChange.Invoke(this);
        }
        return true;
    }
}
