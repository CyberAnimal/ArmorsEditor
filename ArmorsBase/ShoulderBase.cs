using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Shoulders", menuName = "Databases/Armors/Shoulders")]
public class ShoulderBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<Shoulder> shoulders;
    [SerializeField, HideInInspector] private Shoulder curentShoulder;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public ShoulderBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Shoulder shoulder = new Shoulder(idCount);
        shoulders.CreateArmorExtension<Shoulder>(curentShoulder, shoulder, ref maxIndex);
    }

    public void RemoveArmor()
    {
        shoulders.RemoveArmorExtension<Shoulder>(curentShoulder);
    }

    public void NextArmor()
    {
        shoulders.NextArmorExtension<Shoulder>(curentShoulder, ref curentIndex);
    }

    public void PreviousArmor()
    {
        shoulders.PreviousArmorExtension<Shoulder>(curentShoulder, ref curentIndex);
    }

    public Shoulder GetArmorOfId(int id)
    {
        return shoulders.Find(x => x.IDShoulder == id);
    }
}
