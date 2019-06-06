using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDisplay : MonoBehaviour
{
    public Transform slotsParent;

    public EquipableItemDisplay
        helmet,
        chest,
        gloves,
        boots,
        weapon,
        accessory;   

    [SerializeField] Hero hero;

    private void OnEnable()
    {
        if (hero != null)
            Prime(hero);

        hero.inventory.Display();        
        Hero.OnChange += Hero_OnChange;
        EquipableItemDisplay.OnClick += EquipableItemDisplay_OnClick;
    }    

    private void OnDisable()
    {
        hero.inventory.Hide();
        Hero.OnChange -= Hero_OnChange;
        EquipableItemDisplay.OnClick -= EquipableItemDisplay_OnClick;
    }
    private void EquipableItemDisplay_OnClick(Item item)
    {
        if(item is EquipableItem)
        {
            if (hero.IsEquipped((EquipableItem)item))
            {
                hero.Dequip((EquipableItem)item);
                hero.inventory.Add(item);
                return;
            }
            if (hero.Equip((EquipableItem)item))
            {               
                
                hero.inventory.Remove(item);
            }
                
        }            
    }
    private void Hero_OnChange(Hero hero)
    {
        if(hero == this.hero)
        {
            Prime(hero);
        }
    }
    public void Prime(Hero hero)
    {
        this.hero = hero;    

        if (helmet != null)
            helmet.Prime(hero.helmet);
        if (chest != null)
            chest.Prime(hero.chest);
        if (gloves != null)
            gloves.Prime(hero.gloves);
        if (boots != null)
            boots.Prime(hero.boots);
        if (weapon != null)
            weapon.Prime(hero.weapon);
        if (accessory != null)
            accessory.Prime(hero.accessory);
    }


    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    

    public void VendorOpened(Inventory inventory)
    {
        EquipableItemDisplay.OnClick -= EquipableItemDisplay_OnClick;        
        //maybe better
        //inventory.onclick += transfer to shop;
        //vendor.onclik += transfer to inventory
    }
    public void VendorCloserd(Inventory inventory)
    {
        EquipableItemDisplay.OnClick += EquipableItemDisplay_OnClick;
    }
    //TRANSFER TO VENDOR
    //INVENTORY.REMOVE
    //VENDOR.ADD
    //SWAP FOR THE OTHER WAY AROUND
  
}
