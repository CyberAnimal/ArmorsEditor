using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BreastBase))]
public class Breast : Editor
{
    private BreastBase breastBase;

    private void Awake()
    {
        breastBase = (BreastBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            breastBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            breastBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            breastBase.PreviousArmor();

        if (GUILayout.Button("->"))
            breastBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
