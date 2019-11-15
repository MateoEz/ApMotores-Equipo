using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Parametters))]
public class EditorM : Editor
{
    private GUIStyle _labelStyle;
    public Color color;
    private void OnEnable()
    {
        _labelStyle = new GUIStyle();
        _labelStyle.fontStyle = FontStyle.Italic;
        _labelStyle.alignment = TextAnchor.MiddleCenter;
    }

    public override void OnInspectorGUI()
    {
        Parametters par = (Parametters)target;
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            EditorGUILayout.HelpBox("NO SE PUEDE EDITAR PARAMETROS DURANTE PLAY MODE", MessageType.Warning);
            return;
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Crear Enemigo."))
        {
            par.SpawnParametters();
        }

        /* if (GUILayout.Button("Eliminar ejercito"))
         {
             enemy.DeleteArmy();
         }*/


    }

}
