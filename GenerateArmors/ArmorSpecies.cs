using System;
using UnityEngine;
using ArmorTemplateExtensions;

namespace ArmorsSpecies
{
    [Serializable]
    public class Armors
    {
        [SerializeField] private string armorName;
        [SerializeField] private string description;

        [SerializeField] private int armor;
        [SerializeField] private int vitality;
        [SerializeField] private int damageResistance;

        [SerializeField] private ProtectionFromElements protectionType;
        [SerializeField] private int value;

        public string ArmorName => armorName;
        public string Description => description;

        public int Armor => armor;
        public int Vitality => vitality;
        public int DamageResistance => damageResistance;

        public ProtectionFromElements ProtectionType => protectionType;
        public int Value => value;
    }

    public enum ProtectionFromElements
    {
        FromFire,
        FromCold,
        FromPoison,
        FromLightning,
        FromArcaneMagic
    }

    [Serializable]
    public class IDCount
    {
        private int idHelmet = 0;
        public int IDHelmet
        {
            get => idHelmet;
            set => idHelmet++;
        }

        private int idBreast = 0;
        public int IDBreast
        {
            get => idBreast;
            set => idBreast++;
        }
        private int idShoulder = 0;
        public int IDShoulder
        {
            get => idShoulder;
            set => idShoulder++;
        }

        private int idBracer = 0;
        public int IDBracer
        {
            get => idBracer;
            set => idBracer++;
        }

        private int idMitten = 0;
        public int IDMitten
        {
            get => idMitten;
            set => idMitten++;
        }

        private int idLegging = 0;
        public int IDLegging
        {
            get => idLegging;
            set => idLegging++;
        }

        private int idBoot = 0;
        public int IDBoot
        {
            get => idBoot;
            set => idBoot++;
        }
    }

    [Serializable]
    public class Helmet : Armors
    {
        [SerializeField] private int criticalDamage;
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 50;

        private int idHelmet;
        public int IDHelmet => idHelmet;

        public int CriticalDamage
        {
            get => criticalDamage;
            set => criticalDamage = criticalDamage.SetIntField(minValue, maxValue, ref value);
        }

        public Helmet(IDCount idCount)
        {
            idCount.IDHelmet++;
            idHelmet = idCount.IDHelmet;
        }
    }

    [Serializable]
    public class Breast : Armors
    {
        [SerializeField] private int attack;
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 40;

        private int idBreast;
        public int IDBreast => idBreast;

        public int Attack
        {
            get => attack;
            set => attack = attack.SetIntField(minValue, maxValue, ref value);
        }

        public Breast(IDCount idCount)
        {
            idCount.IDBreast++;
            idBreast = idCount.IDBreast;
        }
    }

    [Serializable]
    public class Shoulder : Armors
    {
        [SerializeField] private float percentToDamage;
        [SerializeField] private float minValue = 0;
        [SerializeField] private float maxValue = 20;

        private int idShoulder;
        public int IDShoulder => idShoulder;

        public float PercentToDamage
        {
            get => percentToDamage;
            set => percentToDamage = percentToDamage.SetFloatField(minValue, maxValue, ref value);
        }

        public Shoulder(IDCount idCount)
        {
            idCount.IDShoulder++;
            idShoulder = idCount.IDShoulder;
        }
    }

    [Serializable]
    public class Bracer : Armors
    {
        [SerializeField] private float criticalHitChance;
        [SerializeField] private float minValue = 0;
        [SerializeField] private float maxValue = 10;

        private int idBracer;
        public int IDBracer => idBracer;

        public float CriticalHitChance
        {
            get => criticalHitChance;
            set => criticalHitChance = criticalHitChance.SetFloatField(minValue, maxValue, ref value);
        }

        public Bracer(IDCount idCount)
        {
            idCount.IDBracer++;
            idBracer = idCount.IDBracer;
        }
    }

    [Serializable]
    public class Mitten : Armors
    {
        [SerializeField] private int attackSpeed;
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 20;

        private int idMitten;
        public int IDMitten => idMitten;

        public int AttackSpeed
        {
            get => attackSpeed;
            set => attackSpeed = attackSpeed.SetIntField(minValue, maxValue, ref value);
        }

        public Mitten(IDCount idCount)
        {
            idCount.IDMitten++;
            idMitten = idCount.IDMitten;
        }
    }

    [Serializable]
    public class Legging : Armors
    {
        [SerializeField] private float percentToAttackSpeed;
        [SerializeField] private float minValue = 0;
        [SerializeField] private float maxValue = 5;

        private int idLegging;
        public int IDLegging => idLegging;

        public float PercentToAttackSpeed
        {
            get => percentToAttackSpeed;
            set => percentToAttackSpeed = percentToAttackSpeed.SetFloatField(minValue, maxValue, ref value);
        }

        public Legging(IDCount idCount)
        {
            idCount.IDLegging++;
            idLegging = idCount.IDLegging;
        }
    }

    [Serializable]
    public class Boot : Armors
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float minValue = 0;
        [SerializeField] private float maxValue = 20;

        private int idBoot;
        public int IDBoot => idBoot;

        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = movementSpeed.SetFloatField(minValue, maxValue, ref value);
        }

        public Boot(IDCount idCount)
        {
            idCount.IDBoot++;
            idBoot = idCount.IDBoot;
        }
    }

    public interface IArmorsCreator
    {
        public void CreateArmor();
        public void RemoveArmor();
        public void NextArmor();
        public void PreviousArmor();
    }
}

namespace ArmorTemplateExtensions
{
    public static class Extensions
    {
        public static float SetFloatField(this float field, float minValue, float maxValue, ref float value)
        {
            if (field > maxValue)
                field = maxValue;
            if (field < minValue)
                field = minValue;
            value = field;
            return value;
        }

        public static int SetIntField(this int field, int minValue, int maxValue, ref int value)
        {
            if (field > maxValue)
                field = maxValue;
            if (field < minValue)
                field = minValue;
            value = field;
            return value;
        }
    }
}