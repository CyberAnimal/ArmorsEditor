using System;
using System.Collections.Generic;

public class RecordedStats
{
    private List<RecordedStat> curentStatsList;
    public List<RecordedStat> CurentStatsList => curentStatsList;

    public int Count => curentStatsList.Count;

    public RecordedStats()
    {
        curentStatsList = new List<RecordedStat>();
    }

    public int Add(RecordedStat recordedStat)
    {
        if (recordedStat == null)
        {
            throw new ArgumentNullException(nameof(recordedStat), "Stat is null");
        }
        curentStatsList.Add(recordedStat);
        return curentStatsList.Count;
    }
}

public class RecordedStat
{
    private string name;
    private int value;

    public string Name => name;
    public int Value => value;

    public RecordedStat(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}