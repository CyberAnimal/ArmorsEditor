using System.Collections.Generic;
using UnityEngine;
using ArmorsSpecies;

[System.Serializable]
public class ArmorsFromBaseComponent : MonoBehaviour
{
    [SerializeField] private ArmorType armorType;
    [SerializeField, HideInInspector] private int id = 0;

    private Armors armor;
    private ArmorsFromBaseComponent armorsComponent;

    private List<Armors> armors;
    public List<Armors> Armors => armors;

    private HelmetBase helmetBase;
    private BreastBase breastBase;
    private ShoulderBase shoulderBase;
    private BracerBase bracerBase;
    private MittenBase mittenBase;
    private LeggingBase leggingBase;
    private BootBase bootBase;
    
    public ArmorsFromBaseComponent()
    {
        AssignArmor(armorType);
    }

    public List<Armors> AssignArmor(ArmorType armorType) => armorType switch
    {
        ArmorType.Helmet => armorsComponent.AssignHelmet(),
        ArmorType.Breast => armorsComponent.AssignBreast(),
        ArmorType.Shoulder => armorsComponent.AssignShoulder(),
        ArmorType.Bracer => armorsComponent.AssignBracer(),
        ArmorType.Mitten => armorsComponent.AssignMitten(),
        ArmorType.Legging => armorsComponent.AssignLegging(),
        ArmorType.Boot => armorsComponent.AssignBoot(),
        _ => armorsComponent.AssignHelmet()
    };

    private List<Armors> AssignHelmet()
    {
        helmetBase = new HelmetBase();
        armors = new List<Armors>();

        for (int i = 0; i < helmetBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignBreast()
    {
        breastBase = new BreastBase();
        armors = new List<Armors>();

        for (int i = 0; i < breastBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignShoulder()
    {
        shoulderBase = new ShoulderBase();
        armors = new List<Armors>();

        for (int i = 0; i < shoulderBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignBracer()
    {
        bracerBase = new BracerBase();
        armors = new List<Armors>();

        for (int i = 0; i < bracerBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignMitten()
    {
        mittenBase = new MittenBase();
        armors = new List<Armors>();

        for (int i = 0; i < mittenBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignLegging()
    {
        leggingBase = new LeggingBase();
        armors = new List<Armors>();

        for (int i = 0; i < leggingBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
    private List<Armors> AssignBoot()
    {
        bootBase = new BootBase();
        armors = new List<Armors>();

        for (int i = 0; i < bootBase.MaxIndex; i++)
        {
            var armor = helmetBase.GetArmorOfId(id);
            armors.Add(armor);
            id++;
        }

        return armors;
    }
}

public class ArmorsFromBase
{
    private ArmorsFromBaseComponent component;

    private List<Armors> armors;
    public List<Armors> Armors => armors;

    public ArmorsFromBase(List<Armors> armors, Armors armor)
    {
        component = new ArmorsFromBaseComponent();

        if (armor is Helmet)
        {
            component.AssignArmor(ArmorType.Helmet);
        }

        if (armor is Breast)
        {
            component.AssignArmor(ArmorType.Breast);
        }

        if (armor is Shoulder)
        {
            component.AssignArmor(ArmorType.Shoulder);
        }

        if (armor is Bracer)
        {
            component.AssignArmor(ArmorType.Bracer);
        }

        if (armor is Mitten)
        {
            component.AssignArmor(ArmorType.Mitten);
        }

        if (armor is Legging)
        {
            component.AssignArmor(ArmorType.Legging);
        }

        if (armor is Boot)
        {
            component.AssignArmor(ArmorType.Boot);
        }

        armors = this.armors;
    }
}

public enum ArmorType
{
    Helmet, 
    Breast, 
    Shoulder, 
    Bracer, 
    Mitten, 
    Legging, 
    Boot
}