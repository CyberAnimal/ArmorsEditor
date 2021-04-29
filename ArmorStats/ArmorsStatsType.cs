using System;
using System.Linq;
using System.Collections.Generic;

public class ArmorsStatsType
{
    private ArmorRanksComponent armorRanksComponent;
    private DropFromArmorType dropFromArmorType;

    private int[] chancesOnDrop;
    private int valueChanceDrop;

    public ArmorsStatsType(int quantity)
    {
        armorRanksComponent = new ArmorRanksComponent(chancesOnDrop);
        dropFromArmorType = new DropFromArmorType();
        MakeDrop(quantity);
    }

    private int MakeDrop(int quantity)
    {
        dropFromArmorType.Drop(chancesOnDrop, valueChanceDrop);
        armorRanksComponent.GetQuantity(valueChanceDrop, quantity);
        return quantity;
    }
}

public class Rank
{
    private int value—hanceDrop;
    private string name;
    private int quantityStats;

    public int Value—hanceDrop => value—hanceDrop;
    public string Name => name;
    public int QuantityStats => quantityStats;

    public Rank(int value—hanceDrop, string name, int quantityStats)
    {
        this.value—hanceDrop = value—hanceDrop;
        this.name = name;
        this.quantityStats = quantityStats;
    }
}

public class ArmorRanks
{
    public Rank Regular { get; } = new Rank(1000, "Regular", 1);
    public Rank Rare { get; } = new Rank(500, "Rare", 3);
    public Rank Unique { get; } = new Rank(100, "Unique", 5);
    public Rank Legendary { get; } = new Rank(10, "Legendary", 7);

    private readonly List<Rank> allRank = new List<Rank>();
    public List<Rank> AllRank => allRank;

    public ArmorRanks()
    {
        InitiateRank();
    }
    
    private void InitiateRank()
    {
        var rank = new ArmorRanks()
        {
            AllRank =
            {
                Regular,
                Rare,
                Unique,
                Legendary
            }
        };
    }
}

public class ArmorRanksComponent
{
    private int regular;
    private int rare;
    private int unique;
    private int legendary;

    private ArmorRanks armorRanks;

    public ArmorRanksComponent(int[] ChancesOnDrop)
    {
        armorRanks = new ArmorRanks();
        InitiateChangeOnDrop(ChancesOnDrop);
    }

    private int[] InitiateChangeOnDrop(int[] ChancesOnDrop)
    {
        regular = armorRanks.AllRank.Select(x => x.Value—hanceDrop)
                                    .Where(x => armorRanks.AllRank.Contains(armorRanks.Regular))
                                    .FirstOrDefault();

        rare = armorRanks.AllRank.Select(x => x.Value—hanceDrop)
                                 .Where(x => armorRanks.AllRank.Contains(armorRanks.Rare))
                                 .FirstOrDefault();

        unique = armorRanks.AllRank.Select(x => x.Value—hanceDrop)
                                   .Where(x => armorRanks.AllRank.Contains(armorRanks.Unique))
                                   .FirstOrDefault();

        legendary = armorRanks.AllRank.Select(x => x.Value—hanceDrop)
                                      .Where(x => armorRanks.AllRank.Contains(armorRanks.Legendary))
                                      .FirstOrDefault();

        ChancesOnDrop = new int[] { regular, rare, unique, legendary };
        return ChancesOnDrop;
    }

    public int GetQuantity(int chanceOnDrop, int quantity)
    {
        quantity = armorRanks.AllRank.Where(x => x.Value—hanceDrop == chanceOnDrop)
                                     .Select(x => x.QuantityStats)
                                     .FirstOrDefault();

        return quantity;
    }
}

public class DropFromArmorType
{
    public int Drop(int[] rankComposition, int value)
    {
        var max = rankComposition.Max();
        var sum = max * rankComposition.Sum();
        var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
        var rndRange = rnd.Next(0, sum - 1);
        int curentSum = 0;
        value = rankComposition[0];

        for (int i = 0; i < rankComposition.Length; i++)
        {
            value = rankComposition[i];
            if (rndRange > curentSum && rndRange < curentSum + max * rankComposition[i])
                return value;
            curentSum += max * rankComposition[i];
        }
        return value;
    }
}