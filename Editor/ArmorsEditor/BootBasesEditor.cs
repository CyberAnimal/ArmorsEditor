using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BootBase))]
public class Boot : Editor
{
    private BootBase bootBase;

    private void Awake()
    {
        bootBase = (BootBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Armor"))
            bootBase.CreateArmor();

        if (GUILayout.Button("Remove"))
            bootBase.RemoveArmor();

        if (GUILayout.Button("<-"))
            bootBase.PreviousArmor();

        if (GUILayout.Button("->"))
            bootBase.NextArmor();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
