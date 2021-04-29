using System;
using System.Collections.Generic;
using System.Linq;

public class CompositionStats
{
    private ArmorsStats armorsStats;
    private RecordedStats recordedStats;
    private List<string> sortStats;

    public CompositionStats(RecordedStats newStats, int quantity)
    {
        armorsStats = new ArmorsStats();
        recordedStats = new RecordedStats();
        MakeStatsForArmors(newStats, quantity);
    }

    private RecordedStats MakeStatsForArmors(RecordedStats newStats, int quantity)
    {
        SortingStats();
        InstallStats(quantity, sortStats);
        newStats = recordedStats;
        return newStats;
    }

    private void MakeMixedList(IList<string> list)
    {
        Random rand = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
        SortedList<int, string> mixedStats = new SortedList<int, string>();

        foreach (string item in list)
        {
            mixedStats.Add(rand.Next(), item);
        }

        list.Clear();

        for (int i = 0; i < mixedStats.Count; i++)
        {
            list.Add(mixedStats.Values[i]);
        }
    }

    private IEnumerable<List<string>> SortingStats()
    {
        sortStats = new List<string>();

        foreach (var stat in armorsStats.GetStats())
        {
            string sortStat = stat.Name;
            sortStats.Add(sortStat);
        }

        MakeMixedList(sortStats);
        yield return sortStats;
    }

    private IEnumerable<RecordedStats> InstallStats(int statsQuantity, List<string> sortStats)
    {
        int sortStatsCount = 0;
        int indexOfList = 0;

        do
        {
            foreach (var stat in armorsStats.GetStats())
            {
                var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
                int value = rnd.Next(stat.MinValue, stat.MaxValue);

                if (stat.Name == sortStats[indexOfList])
                {
                    if (recordedStats.Count < statsQuantity)
                    {
                        recordedStats.Add(new RecordedStat(stat.Name, value));
                        sortStatsCount++;
                    }
                    indexOfList++;
                }
            }

            SortingStats();
            indexOfList = 0;
        }
        while (sortStatsCount < statsQuantity);

        yield return recordedStats;
    }
}