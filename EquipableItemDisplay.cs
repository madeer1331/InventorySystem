using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItemDisplay : ItemDisplay
{
    public EquipmentType equipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = equipmentType.ToString() + " Slot";
    }
    public override void Start()
    {
        base.Start();
    }

    public override void Prime(Item item)
    {
        base.Prime(item);
    }

    public override void Click()
    {
        base.Click();
    }
}
