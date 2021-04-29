using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorBaseExtensions;
using ArmorsSpecies;

[CreateAssetMenu(fileName = "New Helmets", menuName = "Databases/Armors/Helmets")]
public class HelmetBase : ScriptableObject, IArmorsCreator
{
    [SerializeField, HideInInspector] private List<Helmet> helmets;
    [SerializeField, HideInInspector] private Helmet curentHelmet;
    [SerializeField, HideInInspector] private IDCount idCount;

    private int curentIndex = 0;

    private int maxIndex = 0;
    public int MaxIndex => maxIndex;

    public HelmetBase()
    {
        idCount = new IDCount();
    }

    public void CreateArmor()
    {
        Helmet helmet = new Helmet(idCount);
        helmets.CreateArmorExtension<Helmet>(curentHelmet, helmet, ref maxIndex);
    }

    public void RemoveArmor()
    {
        helmets.RemoveArmorExtension<Helmet>(curentHelmet);
    }

    public void NextArmor()
    {
        helmets.NextArmorExtension<Helmet>(curentHelmet, ref curentIndex);
    }

    public void PreviousArmor()
    {
        helmets.PreviousArmorExtension<Helmet>(curentHelmet, ref curentIndex);
    }

    public Helmet GetArmorOfId(int id)
    {
        return helmets.Find(x => x.IDHelmet == id);
    }
}

namespace ArmorBaseExtensions
{
    public static class Extensions
    {
        public static void CreateArmorExtension<T>(this List<T> armors, T curentArmor, T localArmor, ref int maxIndex) where T : Armors
        {
            armors ??= new List<T>();
            armors.Add(localArmor);
            curentArmor = localArmor;
            maxIndex++;
        }

        public static void RemoveArmorExtension<T>(this List<T> armors, T curentArmor) where T : Armors
        {
            if (armors == null || curentArmor == null) return;
            armors.Remove(curentArmor);
        }

        public static void NextArmorExtension<T>(this List<T> armors, T curentArmor, ref int curentIndex) where T : Armors
        {
            if (curentIndex + 1 < armors.Count)
            {
                curentIndex++;
                curentArmor = armors[curentIndex];
            }
        }

        public static void PreviousArmorExtension<T>(this List<T> armors, T curentArmor, ref int curentIndex) where T : Armors
        {
            if (curentIndex > 0)
            {
                curentIndex--;
                curentArmor = armors[curentIndex];
            }
        }
    }
}