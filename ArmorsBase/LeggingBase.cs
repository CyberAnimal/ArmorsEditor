using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Leggings", menuName = "Databases/Armors/Leggings")]
public class LeggingBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Legging> leggings;
    [SerializeField, HideInInspector] private Legging curentLegging;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public LeggingBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Legging legging = new Legging(idCount);
        leggings.CreateArmorExtension<Legging>(curentLegging, legging, ref maxIndex);
    }

    public void RemoveArmor()
    {
        leggings.RemoveArmorExtension<Legging>(curentLegging);
    }

    public void NextArmor()
    {
        leggings.NextArmorExtension<Legging>(curentLegging, ref curentIndex);
    }

    public void PreviousArmor()
    {
        leggings.PreviousArmorExtension<Legging>(curentLegging, ref curentIndex);
    }

    public Legging GetArmorOfId(int id)
    {
        return leggings.Find(x => x.IDLegging == id);
    }
}
