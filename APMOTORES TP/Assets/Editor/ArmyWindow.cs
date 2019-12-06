using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmyWindow : EditorWindow
{

   [MenuItem("Army/Creator/Soldier Settings")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ArmyWindow));
        
    }


    public static ArmyWindow Instance;
    public ArmySettings armySet;
    public SoldierSettings soldierSet;
    public ScriptableObject soldierConfig;
    public ScriptableObject armyConfig;
    public GameObject wp;
    public GameObject singleSoldierSpawned;
    public Vector3 pos;
    public Quaternion Rotation;
    public Vector3 soldierSpawnPos;
    public Vector3 Scale;
    public int NumOfEnemies;
    float spawnRadius = 5f;
    private GUIStyle labelStyle;
    float objectScale;
    public static bool second;
    string nameBase = "";
    string save;
    public int NumofWaypoints;

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

    public void SpawnSoldier()
    {
        //soldierSet.name = soldierSet.prefabSoldier.name;
        Instantiate(soldierSet.prefabSoldier, soldierSet.initialPos, Rotation);
        soldierSet.prefabSoldier.GetComponent<Enemy>().life = soldierSet.life;
        soldierSet.prefabSoldier.GetComponent<Enemy>().damage = soldierSet.damage;
        soldierSet.prefabSoldier.GetComponent<Enemy>().velocity = soldierSet.speed;
        soldierSet.prefabSoldier.transform.position = soldierSet.initialPos;
        Scale = new Vector3(1, 1, 1);
        soldierSet.prefabSoldier.transform.localScale = Scale;
        
    }

    private void Awake()
    {
         Instance = this;
    }

    public void SpawnWaypoint()
    {
        GameObject objectNull = Instantiate(wp,pos,Quaternion.identity);
        objectNull.transform.position = pos;
        objectNull.name = nameBase;
        NumofWaypoints++;
    }
    private void OnGUI()
    {
        //GUILayout.Label("Create Spawnpoint",EditorStyles.boldLabel);
        EditorGUILayout.Space();
        //wp = EditorGUILayout.ObjectField("Waypoint Prefab", wp, typeof(GameObject), false) as GameObject;
        EditorGUILayout.Space();
        EditorGUILayout.Space();
       // nameBase = EditorGUILayout.TextField("Spawnpoint name", nameBase);
        /*EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();*/
        /*spawnRadius = EditorGUILayout.FloatField("Distancia de creacion", spawnRadius);
        objectScale = EditorGUILayout.Slider("Tamaño del objeto", objectScale, 0.5f, 3f);*/

       /* if (GUILayout.Button("Create spawn position"))
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
        }*/
       /* if (GUILayout.Button("test"))
        {
            second = true;
            var w = GetWindow<SoldierWindow>();
            w.Show();
        }*/
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("Create Soldiers", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Soldiers Settings"))
        {
            soldierConfig = ScriptableObject.CreateInstance<SoldierSettings>();
            save = "Assets/Scriptable Objects/" + "SoldierConfig.asset";
            Debug.Log("Soldier settings created in the scriptable objects folder");
            AssetDatabase.CreateAsset(soldierConfig, save);
            second = true;
            var w = GetWindow<SoldierWindow>();
            w.Show();
            Save();
            var ww = GetWindow<ArmyWindow>();

        }

        EditorGUILayout.Space();

        /*soldierSet = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Configuration", soldierSet, typeof(SoldierSettings), false);

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
            if (soldierSet != null)
                SpawnSoldier();
            else if(soldierSet == null)
                Debug.LogWarning("Error: Please drag Soldier Settings");
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        */
        GUILayout.Label("Create Armys", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button ("Create Army Settings"))
        {
            armyConfig = ScriptableObject.CreateInstance<ArmySettings>();
            save = "Assets/Scriptable Objects/" + "ArmyConfig.asset";
            Debug.Log("Army settings created in the scriptable objects folder");
            AssetDatabase.CreateAsset(armyConfig, save);
            var w = GetWindow<ArmySettingsWindow>();
            w.a = NumofWaypoints;
            w.Show();
            Save();
        }

        /*EditorGUILayout.Space();

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
            if(armySet != null)
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
        */
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
