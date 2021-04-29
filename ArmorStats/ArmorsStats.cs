using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmorsStats", menuName = "Databases/ArmorsStats")]
public class ArmorsStats : ScriptableObject
{
    [SerializeField] private List<Stat> stats;
    [SerializeField] private Stat curentStat;

    public int Count => stats.Count;

    public ArmorsStats()
    {
        stats = new List<Stat>();
    }

    public Stat this[string name]
    {
        get
        {
            var stat = stats.FirstOrDefault(s => s.Name == name);
            return stat;
        }
    }

    public int CreateStat()
    {
        Stat stat = new Stat();
        stats.Add(stat);
        curentStat = stat;
        return stats.Count;
    }
    
    public int RemoveArmor()
    {
        stats.Remove(curentStat);
        return stats.Count;
    }

    public IEnumerable<Stat> GetStats()
    {
        return stats;
    }
}

public class Stat
{
    [SerializeField] private int minValue = 0;
    [SerializeField] private int maxValue = 30;
    [SerializeField] private string name;

    public string Name => name;
    public int MinValue => minValue;
    public int MaxValue => maxValue;

    public Stat(string name, int minValue, int maxValue)
    {
        this.name = name;
        this.minValue = minValue;
        this.maxValue = maxValue;
    }
    public Stat() { }
}