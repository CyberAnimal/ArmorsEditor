using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MittenBase))]
public class Mitten : Editor
{
    private MittenBase mittenBase;

    private void Awake()
    {
        mittenBase = (MittenBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            mittenBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            mittenBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            mittenBase.PreviousArmor();

        if (GUILayout.Button("->"))
            mittenBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
