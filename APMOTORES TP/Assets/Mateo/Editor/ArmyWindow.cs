using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmyWindow : EditorWindow
{
  [MenuItem("Army/Creator")]
    //[MenuItem("OtraWindow/Sinecesitamos")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ArmyWindow));
    }

    GameObject objetSpawn;
    public Vector3 pos;
    float spawnRadius = 5f;
    private GUIStyle labelStyle;
    float objectScale;
    string nameBase = "";


    private void OnEnable()
    {
        /*labelStyle.fontSize = 3;
        labelStyle.fontStyle = FontStyle.BoldAndItalic;*/
        //labelStyle.alignment = TextAnchor.MiddleCenter;
    }
    /*private void SpawnObject()
    {
        //Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        //Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objetSpawn,pos,Quaternion.identity);
        newObject.transform.localScale = Vector3.one * objectScale;
        if (objetSpawn == null)
        {
            Debug.LogError("Error: Porfavor asigna un objeto para crear.");
            return;
        }

    }*/

    public void SpawnGameObject()
    {
        GameObject objectNull = Instantiate(objetSpawn,pos,Quaternion.identity);
        objectNull.transform.position = pos;
        objectNull.name = nameBase;
        /*if (objetSpawn == null)
        {
            Debug.LogWarning("Error. Please drag an object ");
            return;
        }
        if (nameBase == string.Empty)
        {
            Debug.LogWarning("Error: Please enter a name");
            return;
        }*/
    }
    private void OnGUI()
    {
        GUILayout.Label("Create spawn object",EditorStyles.boldLabel);
        EditorGUILayout.Space();
        objetSpawn = EditorGUILayout.ObjectField("Prefab to spawn", objetSpawn, typeof(GameObject), false) as GameObject;
        EditorGUILayout.Space();
        pos = EditorGUILayout.Vector3Field("Spawn position", pos);
        EditorGUILayout.Space();
        nameBase = EditorGUILayout.TextField("Spawn point name", nameBase);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        /*spawnRadius = EditorGUILayout.FloatField("Distancia de creacion", spawnRadius);
        objectScale = EditorGUILayout.Slider("Tamaño del objeto", objectScale, 0.5f, 3f);*/

        if (GUILayout.Button("Create spawn position"))
        {

            if (objetSpawn == null)
            {
                Debug.LogWarning("Error. Please drag an object ");
                return;
            }
            if (nameBase == string.Empty)
            {
                Debug.LogWarning("Error: Please enter a name");
                return;
            }
            SpawnGameObject();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Create enemy settings"))
        {

        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button ("Create army configuration"))
        {

        }

        /*if (GUILayout.Button("Spawnear objeto"))
        {
            SpawnObject();
        }*/
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Close"))
        {

            Close();
        }
    }
}
