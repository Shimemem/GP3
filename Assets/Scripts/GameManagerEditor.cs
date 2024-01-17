using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        GameManager manager = (GameManager)target;

        if (GUILayout.Button("Add PowerUp: Focus"))
        {
            manager.DamagePowerUp_Focus();
        }
        if (GUILayout.Button("Add PowerUp: Concentration"))
        {
            manager.DamagePowerUp_Concentration();
        }
        if (GUILayout.Button("AddEXP"))
        {
            manager.AddExp(manager.expToAdd);
        }
        if (GUILayout.Button("Reset"))
        {
            manager.ResetValues();
        }

    }
}
