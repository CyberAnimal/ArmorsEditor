using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShoulderBase))]
public class Shoulder : Editor
{
    private ShoulderBase shoulderBase;

    private void Awake()
    {
        shoulderBase = (ShoulderBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            shoulderBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            shoulderBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            shoulderBase.PreviousArmor();

        if (GUILayout.Button("->"))
            shoulderBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
