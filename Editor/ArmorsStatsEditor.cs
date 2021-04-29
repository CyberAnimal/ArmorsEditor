using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ArmorsStats))]
public class ArmorsStatsEditor : Editor
{
    private ArmorsStats armorsStats;

    private void Awake()
    {
        armorsStats = (ArmorsStats)target;
        armorsStats = new ArmorsStats();
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Stat"))
            armorsStats.CreateStat();

        if (GUILayout.Button("Remove"))
            armorsStats.RemoveArmor();
        
        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
