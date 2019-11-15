using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmyWindow : EditorWindow
{
<<<<<<< HEAD:APMOTORES TP/Assets/Mateo/Editor/ArmyWindow.cs
    [MenuItem("Army/Creator")]
=======
  [MenuItem("Army/Creator")]

>>>>>>> 964fb300ec491da3a8601f0b75e0055e61981b6c:APMOTORES TP/Assets/Editor/ArmyWindow.cs
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
<<<<<<< HEAD:APMOTORES TP/Assets/Mateo/Editor/ArmyWindow.cs
    public Enemy singleSoldierSpawned;
=======
    public static bool openSecond = false;
    public GameObject singleSoldierSpawned;
>>>>>>> 964fb300ec491da3a8601f0b75e0055e61981b6c:APMOTORES TP/Assets/Editor/ArmyWindow.cs
    public Vector3 pos;
    public Quaternion Rotation;
    public Vector3 soldierSpawnPos;
    public Vector3 Scale;
    public Vector3 rot;
    public int NumOfEnemies;
    float spawnRadius = 5f;
    private GUIStyle labelStyle;
    float objectScale;
    string nameBase = "";
    string save;
    public List<GameObject> NumOfWp = new List<GameObject>();

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
        NumOfWp.Add(objectNull);
    }

    public void SpawnSoldier()
    {
       
       var spawned = Instantiate(singleSoldierSpawned, pos, Rotation);
        if(Scale.y <= 0)
        {
            Scale.y = 1;
        }
        else if(Scale.x <= 0)
        {
            Scale.x = 1;
        }
        else if(Scale.z <= 0)
        {
            Scale.z = 1;
        }
        else
        {
            spawned.transform.localScale = Scale;
        }
       pos = pos + Vector3.right * 3;
       spawned.life = soldierSet.life;
       spawned.damage = soldierSet.damage;
       spawned.velocity = soldierSet.speed;



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

        /*if (GUILayout.Button("Create Soldiers Settings"))
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
             Scale = EditorGUILayout.Vector3Field("Scale", Scale);
             rot = EditorGUILayout.Vector3Field("rot", rot);
            Rotation = Quaternion.Euler(rot);
            singleSoldierSpawned = (Enemy)EditorGUILayout.ObjectField("Soldier Prefab", singleSoldierSpawned, typeof(Enemy), false);
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
        GUILayout.Label("Create Armys", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button ("Create Army Settings"))
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
<<<<<<< HEAD:APMOTORES TP/Assets/Mateo/Editor/ArmyWindow.cs
            foreach (var item in NumOfWp)
            {

                var spawned = Instantiate(singleSoldierSpawned, item.transform.position, Rotation);
                spawned.life = soldierSet.life;
                spawned.damage = soldierSet.damage;
                spawned.velocity = soldierSet.speed;
                spawned.transform.localScale = Scale;
=======
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
>>>>>>> 964fb300ec491da3a8601f0b75e0055e61981b6c:APMOTORES TP/Assets/Editor/ArmyWindow.cs
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
        */
        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }
}
