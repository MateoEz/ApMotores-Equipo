using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SoldierWindow : ArmyWindow
{
    public GameObject preView;
    private void OnGUI()
    {

        soldierSet = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Configuration", soldierSet, typeof(SoldierSettings), false);

        preView = (GameObject)EditorGUILayout.ObjectField("PreView",preView,typeof( GameObject), true);

        if (soldierSet != null)
        {
            //soldierSet.name = EditorGUILayout.TextField("Name", soldierSet.name);
            if (preView != null)
            {
                soldierSet.initialPos = EditorGUILayout.Vector3Field("Initial position", soldierSet.initialPos);
                //pongo el objeto en la posision
                preView.transform.position = soldierSet.initialPos;
            }
            soldierSet.prefabSoldier = (GameObject)EditorGUILayout.ObjectField("Soldier Prefab", soldierSet.prefabSoldier, typeof(GameObject), false);
            soldierSet.damage = EditorGUILayout.IntField("Damage", soldierSet.damage);
            soldierSet.life = EditorGUILayout.IntField("Life", soldierSet.life);
            soldierSet.speed = EditorGUILayout.IntField("Speed", soldierSet.speed);
            EditorUtility.SetDirty(soldierSet);
        }

        EditorGUILayout.Space();
        
        if (GUILayout.Button("Spawn Soldier"))
        {
            if (ArmyWindow.Instance.soldierSet != null && soldierSet.prefabSoldier != null)
            {
                AssetDatabase.Refresh();
                SpawnSoldier();
            }

            else if (ArmyWindow.Instance.soldierSet == null)
                Debug.LogWarning("Error: Please drag Soldier Settings");
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }


   /* private void OnSceneGUI()
    {


        //seteá el color 
        Handles.color = Color.red;

        //la distancia en tre las linitas y el point 
        float PointScope = 2;

        //las liñtas
        Handles.DrawLine(soldierSet.initialPos, soldierSet.initialPos + Vector3.right * PointScope);

        Handles.DrawLine(soldierSet.initialPos, soldierSet.initialPos - Vector3.right * PointScope);

        Handles.DrawLine(soldierSet.initialPos, soldierSet.initialPos + Vector3.forward * PointScope);

        Handles.DrawLine(soldierSet.initialPos, soldierSet.initialPos - Vector3.forward * PointScope);

        // los dos circulos
        Handles.DrawSolidDisc(soldierSet.initialPos, Vector3.up, PointScope / 2);
        Handles.DrawWireDisc(soldierSet.initialPos, Vector3.up, PointScope);
    }*/

}
