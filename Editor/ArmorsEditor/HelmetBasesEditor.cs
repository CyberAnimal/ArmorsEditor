using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HelmetBase))]
public class HelmetBasesEditor : Editor
{
    private HelmetBase helmetBase;

    private void Awake()
    {
        helmetBase = (HelmetBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            helmetBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            helmetBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            helmetBase.PreviousArmor();

        if (GUILayout.Button("->"))
            helmetBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
