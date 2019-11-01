using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemies))]
public class EnemiesEditor : Editor
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
        Enemies enemy = (Enemies)target;
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            EditorGUILayout.HelpBox("NO SE PUEDE EDITAR PARAMETROS DURANTE PLAY MODE", MessageType.Warning);
            return;
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
       // EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.red);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.TextField("No afecta la Y del vector3.",_labelStyle);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.red);
        EditorGUILayout.Space();
        GUILayout.TextField("FORMACION", _labelStyle);
        EditorGUILayout.Space();
        GUILayout.TextField("Cuadrado",_labelStyle);
        EditorGUILayout.Space();
        if (GUILayout.Button("Crear ejercito en la posicion indicada."))
        {
            enemy.SpawnEnemiesSquare();
        }

       if (GUILayout.Button("Eliminar ejercito"))
        {
            enemy.DeleteArmySquare();
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.TextField("Triangulo", _labelStyle);
        EditorGUILayout.Space();
        if (GUILayout.Button("Crear ejercito en la posicion indicada."))
        {
            enemy.SpawnEnemiesTriangle();
        }
        if (GUILayout.Button("Eliminar ejercito"))
        {
            enemy.DeleteArmyTriangle();
        }
        EditorGUILayout.Space();
        GUILayout.TextField("Circulo", _labelStyle);
        EditorGUILayout.Space();
        if (GUILayout.Button("Crear ejercito en la posicion indicada."))
        {
            enemy.SpawnEnemiesCircle();
        }
        if (GUILayout.Button("Eliminar ejercito"))
        {
            enemy.DeleteArmyCircle();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.red);
    }


}
