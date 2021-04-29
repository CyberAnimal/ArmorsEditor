using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Breasts", menuName = "Databases/Armors/Breasts")]
public class BreastBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Breast> breasts;
    [SerializeField, HideInInspector] private Breast curentBreast;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public BreastBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Breast breast = new Breast(idCount);
        breasts.CreateArmorExtension<Breast>(curentBreast, breast, ref maxIndex);
    }

    public void RemoveArmor()
    {
        breasts.RemoveArmorExtension<Breast>(curentBreast);
    }

    public void NextArmor()
    {
        breasts.NextArmorExtension<Breast>(curentBreast, ref curentIndex);
    }

    public void PreviousArmor()
    {
        breasts.PreviousArmorExtension<Breast>(curentBreast, ref curentIndex);
    }

    public Breast GetArmorOfId(int id)
    {
        return breasts.Find(x => x.IDBreast == id);
    }
}
