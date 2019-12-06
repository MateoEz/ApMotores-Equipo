using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArmySettingsWindow : ArmyWindow
{
    public int a;
    public GameObject preView;
    public void OnGUI()
    {

        armySet = (ArmySettings)EditorGUILayout.ObjectField("Army Configuration", armySet, typeof(ArmySettings), false);
       
        preView = (GameObject)EditorGUILayout.ObjectField("Preview", preView, typeof(GameObject), true);

        if (armySet != null)
        {
            if (preView != null)
            {
                armySet.initialPos = EditorGUILayout.Vector3Field("Spawn Position Army", armySet.initialPos);
                //pongo el objeto en el lugar
                preView.transform.position = armySet.initialPos;
            }
            armySet.soldierPreset = (SoldierSettings)EditorGUILayout.ObjectField("Soldier Preset", armySet.soldierPreset, typeof(SoldierSettings), false);
            armySet.numberOfSoldiers = EditorGUILayout.IntField("Number of Soldiers", armySet.numberOfSoldiers);
            armySet.queueFormation = EditorGUILayout.Toggle("Queue Formation", armySet.queueFormation);
            armySet.randomFormation = EditorGUILayout.Toggle("Random Formation", armySet.randomFormation);
            EditorUtility.SetDirty(armySet);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Spawn Army"))
        {
            if (armySet.queueFormation)
            {
                if (armySet != null)
                {
                    for (int i = 0; i < armySet.numberOfSoldiers; i++)
                    {
                        Instantiate(armySet.soldierPreset.prefabSoldier, armySet.initialPos, Rotation);
                        armySet.initialPos = armySet.initialPos + Vector3.forward * 2;
                    }
                }
            }
            if (armySet.randomFormation)
            {
                for (int i = 0; i < armySet.numberOfSoldiers; i++)
                {
                    Instantiate(armySet.soldierPreset.prefabSoldier, armySet.initialPos, Rotation);
                    armySet.initialPos = armySet.initialPos + new Vector3(Random.Range(1, 10), 0, Random.Range(1, 10));
                }
            }
        }

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }

   
}



