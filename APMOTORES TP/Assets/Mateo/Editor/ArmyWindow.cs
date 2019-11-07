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

    ArmySettings armySet;
    SoldierSettings soldierSet;
    ScriptableObject soldierConfig;
    ScriptableObject armyConfig;
    GameObject wp;
    GameObject singleSoldierSpawned;
    public Vector3 pos;
    public Vector3 soldierSpawnPos;
    float spawnRadius = 5f;
    private GUIStyle labelStyle;
    float objectScale;
    string nameBase = "";
    string save;

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

    public void SpawnWaypoint()
    {
        GameObject objectNull = Instantiate(wp,pos,Quaternion.identity);
        objectNull.transform.position = pos;
        objectNull.name = nameBase;
    }

    public void SpawnSoldier()
    {
        
    } 

    private void OnGUI()
    {
        GUILayout.Label("Create Spawnpoint",EditorStyles.boldLabel);
        EditorGUILayout.Space();
        wp = EditorGUILayout.ObjectField("Waypoint Prefab", wp, typeof(GameObject), false) as GameObject;
        EditorGUILayout.Space();
        pos = EditorGUILayout.Vector3Field("Spawn position", pos);
        EditorGUILayout.Space();
        nameBase = EditorGUILayout.TextField("Spawnpoint name", nameBase);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        /*spawnRadius = EditorGUILayout.FloatField("Distancia de creacion", spawnRadius);
        objectScale = EditorGUILayout.Slider("Tamaño del objeto", objectScale, 0.5f, 3f);*/

        if (GUILayout.Button("Create spawn position"))
        {

            if (wp == null)
            {
                Debug.LogWarning("Error. Please drag an object ");
                return;
            }
            if (nameBase == string.Empty)
            {
                Debug.LogWarning("Error: Please enter a name");
                return;
            }
            SpawnWaypoint();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("Create Soldiers", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Soldiers Settings"))
        {
            soldierConfig = ScriptableObject.CreateInstance<SoldierSettings>();
            save = "Assets/" + "SoldierConfig.asset";
            AssetDatabase.CreateAsset(soldierConfig, save);
            Save();
        }

        EditorGUILayout.Space();

        soldierSet = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Configuration", soldierSet, typeof(SoldierSettings), false);

        if(soldierSet != null)
        {
            soldierSet.life = EditorGUILayout.IntField("Life", soldierSet.life);
            soldierSet.speed = EditorGUILayout.IntField("Speed", soldierSet.speed);
            soldierSet.damage = EditorGUILayout.IntField("Damage", soldierSet.damage);
            soldierSet.prefabSoldier = (GameObject)EditorGUILayout.ObjectField("Soldier Prefab", soldierSet.prefabSoldier,typeof(GameObject), false);
            EditorUtility.SetDirty(soldierSet);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Spawn Soldier"))
        {
            SpawnSoldier();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("Create Armys", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button ("Create Army Settings"))
        {
            armyConfig = ScriptableObject.CreateInstance<ArmySettings>();
            save = "Assets/" + "ArmyConfig.asset";
            AssetDatabase.CreateAsset(armyConfig, save);
            Save();
        }

        EditorGUILayout.Space();

        armySet = (ArmySettings)EditorGUILayout.ObjectField("Army Configuration", armySet, typeof(ArmySettings), false);

        if (armySet != null)
        {
            armySet.soldierPreset = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Preset", armySet.soldierPreset, typeof(SoldierSettings), false);
            armySet.numberOfSoldiers = EditorGUILayout.IntField("Number of Soldiers", armySet.numberOfSoldiers);
            armySet.squareFormation = EditorGUILayout.Toggle("Square Formation", armySet.squareFormation);
            armySet.triangleFormation = EditorGUILayout.Toggle("Triangle Formation", armySet.triangleFormation);
            armySet.circleFormation = EditorGUILayout.Toggle("Circle Formation", armySet.circleFormation);
            EditorUtility.SetDirty(armySet);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Spawn Army"))
        {

        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        void Save()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }
}
