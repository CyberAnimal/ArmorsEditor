using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Boots", menuName = "Databases/Armors/Boots")]
public class BootBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Boot> boots;
    [SerializeField, HideInInspector] private Boot curentBoot;
    [SerializeField, HideInInspector] private IDCount idCount;
    
    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public BootBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Boot boot = new Boot(idCount);
        boots.CreateArmorExtension<Boot>(curentBoot, boot, ref maxIndex);
    }

    public void RemoveArmor()
    {
        boots.RemoveArmorExtension<Boot>(curentBoot);
    }

    public void NextArmor()
    {
        boots.NextArmorExtension<Boot>(curentBoot, ref curentIndex);
    }

    public void PreviousArmor()
    {
        boots.PreviousArmorExtension<Boot>(curentBoot, ref curentIndex);
    }

    public Boot GetArmorOfId(int id)
    {
        return boots.Find(x => x.IDBoot == id);
    }
}
