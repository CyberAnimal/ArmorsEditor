using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Mittens", menuName = "Databases/Armors/Mittens")]
public class MittenBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Mitten> mittens;
    [SerializeField, HideInInspector] private Mitten curentMitten;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public MittenBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Mitten mitten = new Mitten(idCount);
        mittens.CreateArmorExtension<Mitten>(curentMitten, mitten, ref maxIndex);
    }

    public void RemoveArmor()
    {
        mittens.RemoveArmorExtension<Mitten>(curentMitten);
    }

    public void NextArmor()
    {
        mittens.NextArmorExtension<Mitten>(curentMitten, ref curentIndex);
    }

    public void PreviousArmor()
    {
        mittens.PreviousArmorExtension<Mitten>(curentMitten, ref curentIndex);
    }

    public Mitten GetArmorOfId(int id)
    {
        return mittens.Find(x => x.IDMitten == id);
    }
}
