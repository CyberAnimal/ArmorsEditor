using System;
using System.Collections.Generic;
using System.Linq;
using ArmorsSpecies;

public class CreateArmorType
{
    private ArmorsFromBase armorsFromBase;

    private IDCount idCount;

    private Helmet helmet;
    private Breast breast;
    private Shoulder shoulder;
    private Bracer bracer;
    private Mitten mitten;
    private Legging legging;
    private Boot boot;

    public Armors Helmet => helmet;
    public Armors Breast => breast;
    public Armors Shoulder => shoulder;
    public Armors Bracer => bracer;
    public Armors Mitten => mitten;
    public Armors Legging => legging;
    public Armors Boot => boot;

    private List<Armors> armorsType;

    public CreateArmorType(List<Armors> allArmorsFromType, Armors armor)
    {
        InitiateArmors();
        InitiateArmorsList();
        TakeArmor(armor);
        GetTakeArmor(allArmorsFromType, armor);
    }

    private void InitiateArmors()
    {
        idCount = new IDCount();
        helmet = new Helmet(idCount);
        breast = new Breast(idCount);
        shoulder = new Shoulder(idCount);
        bracer = new Bracer(idCount);
        mitten = new Mitten(idCount);
        legging = new Legging(idCount);
        boot = new Boot(idCount);
    }

    private void InitiateArmorsList()
    {
        armorsType = new List<Armors>();
        armorsType.Add(Helmet);
        armorsType.Add(Breast);
        armorsType.Add(Shoulder);
        armorsType.Add(Bracer);
        armorsType.Add(Mitten);
        armorsType.Add(Legging);
        armorsType.Add(Boot);
    }

    private void TakeArmor(Armors armor)
    {
        var rand = new System.Random(Guid.NewGuid().ToByteArray().Sum(x => x));
        var dropChange = rand.Next(0, 100);

        var percent = 100 / armorsType.Count;
        var count = 0;

        do
        {
            if (dropChange <= percent)
            {
                armor = armorsType[count];
            }
            count++;

            if (count >= armorsType.Count)
                count = 0;
        }
        while (armor == null);
    }
    private Armors GetTakeArmor(List<Armors> allArmorsFromType, Armors armor)
    {
        armorsFromBase = new ArmorsFromBase(allArmorsFromType, armor);

        var rnd = new System.Random();
        int randIndex = rnd.Next(0, allArmorsFromType.Count);

        armor = allArmorsFromType[randIndex];
        return armor;
    }
}