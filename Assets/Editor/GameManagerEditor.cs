using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    GameManager Manager;
    private void OnEnable()
    {
        Manager = target as GameManager;
    }
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
        //"Laser Prefab", serializedObject.FindProperty("LaserPrefab"), typeof(GameObject), false,GUILayout.MaxWidth(999)
        
        //EditorGUILayout.ObjectField("Laser Prefab", Manager.LaserPrefab,typeof(GameObject),false);
        //EditorGUILayout.ObjectField("Lives Text", Manager.LivesText, typeof(Text), true);
        base.OnInspectorGUI();
        //serializedObject.ApplyModifiedProperties();
    }
}
