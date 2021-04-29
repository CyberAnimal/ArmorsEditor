using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BracerBase))]
public class Bracer : Editor
{
    private BracerBase bracerBase;

    private void Awake()
    {
        bracerBase = (BracerBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            bracerBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            bracerBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            bracerBase.PreviousArmor();

        if (GUILayout.Button("->"))
            bracerBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
