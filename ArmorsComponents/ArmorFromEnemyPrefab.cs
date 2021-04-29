using ArmorsSpecies;
using System.Collections.Generic;
using UnityEngine;

public class ArmorFromEnemyPrefab : MonoBehaviour
{
    private ArmorFromEnemy armorFromEnemy;
    private CompositionStats compositionStats;
    private ArmorsStatsType armorsStatsType;
    private CreateArmorType createArmorType;

    private void Awake()
    {
        armorFromEnemy = new ArmorFromEnemy(compositionStats, armorsStatsType, createArmorType);
    }
}

public class ArmorFromEnemy
{
    private CompositionStats compositionStats;
    private ArmorsStatsType armorsStatsType;
    private CreateArmorType createArmorType;

    private Armors armor;
    private List<Armors> armors;
    private RecordedStats recordedStats;
    private int quantity;

    public ArmorFromEnemy(CompositionStats compositionStats,
                          ArmorsStatsType armorsStatsType,
                          CreateArmorType createArmorType)
    {
        this.compositionStats = compositionStats;
        this.armorsStatsType = armorsStatsType;
        this.createArmorType = createArmorType;

        CreateArmor(this.compositionStats, this.armorsStatsType, this.createArmorType);
    }
    private void CreateArmor(CompositionStats compositionStats,
                             ArmorsStatsType armorsStatsType,
                             CreateArmorType createArmorType)
    {
        createArmorType = new CreateArmorType(armors, armor);
        armorsStatsType = new ArmorsStatsType(quantity);
        compositionStats = new CompositionStats(recordedStats, quantity);
    }
}