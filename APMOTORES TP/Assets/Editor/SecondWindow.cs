using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SecondWindow : EditorWindow
{
    [MenuItem("Army/Creator/Settings")]
    // Start is called before the first frame update

    public static void ShowWindow()
    {
        GetWindow(typeof(SecondWindow));
        if (ArmyWindow.openSecond == true)
        {
            GetWindow(typeof(ArmyWindow));
            var w = GetWindow<SecondWindow>();
            w.ShowPopup();
        }
    }
    ArmySettings armySet;
    SoldierSettings soldierSet;
    ScriptableObject soldierConfig;
    ScriptableObject armyConfig;
    GameObject wp;
    public static bool openSecond = false;
    public GameObject singleSoldierSpawned;
    public Vector3 pos;
    public Quaternion Rotation;
    public Vector3 soldierSpawnPos;
    public Vector3 Scale;
    public int NumOfEnemies;
    float spawnRadius = 5f;
    private GUIStyle labelStyle;
    float objectScale;
    string nameBase = "";
    string save;
    public int NumofWaypoints;
    public void SpawnSoldier()
    {

        Instantiate(singleSoldierSpawned, pos, Rotation);
        pos = pos + Vector3.right * 2;
        singleSoldierSpawned.GetComponent<Enemy>().life = soldierSet.life;
        singleSoldierSpawned.GetComponent<Enemy>().damage = soldierSet.damage;
        singleSoldierSpawned.GetComponent<Enemy>().velocity = soldierSet.speed;
        singleSoldierSpawned.transform.localScale = Scale;


    }
    public void OnGUI()
    {
        if (GUILayout.Button("Create Soldiers Settings"))
        {
            openSecond = true;
            soldierConfig = ScriptableObject.CreateInstance<SoldierSettings>();
            save = "Assets/Scriptable Objects/" + "SoldierConfig.asset";
            Debug.Log("Soldier settings created in the scriptable objects folder");
            AssetDatabase.CreateAsset(soldierConfig, save);
            Save();
        }

        EditorGUILayout.Space();

        soldierSet = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Configuration", soldierSet, typeof(SoldierSettings), false);

        if (soldierSet != null)
        {
            soldierSet.life = EditorGUILayout.IntField("Life", soldierSet.life);
            soldierSet.speed = EditorGUILayout.IntField("Speed", soldierSet.speed);
            soldierSet.damage = EditorGUILayout.IntField("Damage", soldierSet.damage);
            soldierSet.prefabSoldier = (GameObject)EditorGUILayout.ObjectField("Soldier Prefab", soldierSet.prefabSoldier, typeof(GameObject), false);
            EditorUtility.SetDirty(soldierSet);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Spawn Soldier"))
        {
            if (soldierSet != null)
                SpawnSoldier();
            else if (soldierSet == null)
                Debug.LogWarning("Error: Please drag Soldier Settings");
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("Create Armys", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Army Settings"))
        {
            armyConfig = ScriptableObject.CreateInstance<ArmySettings>();
            save = "Assets/Scriptable Objects/" + "ArmyConfig.asset";
            Debug.Log("Army settings created in the scriptable objects folder");
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
            if (armySet != null)
            {
                for (int i = 0; i < NumofWaypoints; i++)
                {
                    Instantiate(singleSoldierSpawned, wp.transform.position, Rotation);
                    singleSoldierSpawned.GetComponent<Enemy>().life = soldierSet.life;
                    singleSoldierSpawned.GetComponent<Enemy>().damage = soldierSet.damage;
                    singleSoldierSpawned.GetComponent<Enemy>().velocity = soldierSet.speed;
                    singleSoldierSpawned.transform.localScale = Scale;
                }
            }
            else
                Debug.LogWarning("Error: Please drag Army Settings");
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
