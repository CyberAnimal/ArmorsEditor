using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LeggingBase))]
public class Legging : Editor
{
    private LeggingBase leggingBase;

    private void Awake()
    {
        leggingBase = (LeggingBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            leggingBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            leggingBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            leggingBase.PreviousArmor();

        if (GUILayout.Button("->"))
            leggingBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
