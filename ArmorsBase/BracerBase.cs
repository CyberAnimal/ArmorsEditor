using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Bracers", menuName = "Databases/Armors/Bracers")]
public class BracerBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Bracer> bracers;
    [SerializeField, HideInInspector] private Bracer curentBracer;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public BracerBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Bracer bracer = new Bracer(idCount);
        bracers.CreateArmorExtension<Bracer>(curentBracer, bracer, ref maxIndex);
    }

    public void RemoveArmor()
    {
        bracers.RemoveArmorExtension<Bracer>(curentBracer);
    }

    public void NextArmor()
    {
        bracers.NextArmorExtension<Bracer>(curentBracer, ref curentIndex);
    }

    public void PreviousArmor()
    {
        bracers.PreviousArmorExtension<Bracer>(curentBracer, ref curentIndex);
    }

    public Bracer GetArmorOfId(int id)
    {
        return bracers.Find(x => x.IDBracer == id);
    }
}
