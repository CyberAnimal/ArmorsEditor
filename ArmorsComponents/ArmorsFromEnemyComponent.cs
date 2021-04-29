using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmorsSpecies;

public class ArmorsFromEnemyComponent : MonoBehaviour
{
    private ArmorsFromEnemy armorsFromEnemy;

    private int armorsAmount = 10;

    private void start()
    {
        armorsFromEnemy = new ArmorsFromEnemy(armorsAmount);
    }
}

public class ArmorsFromEnemy : MonoBehaviour
{
    private GameObject armorPrefab;

    private List<GameObject> armorsPool;
    public List<GameObject> ArmorsPool => armorsPool;

    public ArmorsFromEnemy(int armorsAmount)
    {
        CreateArmorsList(armorsPool, armorsAmount);
    }

    private void CreateArmorsList(List<GameObject> armorsPool, int armorsAmount)
    {
        for (int i = 0; i < armorsAmount; i++)
        {
            var armor = Instantiate(armorPrefab);
            armor.SetActive(false);
            armorsPool.Add(armor);
        }
    }
}