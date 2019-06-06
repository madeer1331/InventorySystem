using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Glove,
    Boots,
    Weapon,
    Accesorry
}
[CreateAssetMenu]
public class EquipableItem : Item
{
    public int StrenghtBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrenghtPercent;
    public float AgilityPercent;
    public float IntelligencePercent;
    public float VitalityPercent;
    [Space]
    public EquipmentType type;

    public void Equip(Hero h)
    {
        if (StrenghtBonus != 0)
            h.Strenght.AddMod(new StatMod(StrenghtBonus, this));
        if (AgilityBonus != 0)
            h.Agility.AddMod(new StatMod(AgilityBonus, this));
        if (IntelligenceBonus != 0)
            h.Intelligence.AddMod(new StatMod(IntelligenceBonus, this));
        if (VitalityBonus != 0)
            h.Vitality.AddMod(new StatMod(VitalityBonus, this));       
    }
    public void Unequip(Hero h)
    {
        h.Strenght.RemoveAllModFromSource(this);
        h.Agility.RemoveAllModFromSource(this);
        h.Intelligence.RemoveAllModFromSource(this);
        h.Vitality.RemoveAllModFromSource(this);        
    }
}
