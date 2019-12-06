using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Parametters))]
public class EditorM : Editor
{
    //private GUIStyle _labelStyle;
    //public Color color;
    //private void OnEnable()
    //{
    //    _labelStyle = new GUIStyle();
    //    _labelStyle.fontStyle = FontStyle.Italic;
    //    _labelStyle.alignment = TextAnchor.MiddleCenter;
    //}

        Parametters _target;
    public override void OnInspectorGUI()
    {
        _target = (Parametters)target;
        //base.OnInspectorGUI();
        //if (Application.isPlaying)
        //{
        //    EditorGUILayout.HelpBox("NO SE PUEDE EDITAR PARAMETROS DURANTE PLAY MODE", MessageType.Warning);
        //    return;
        //}
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //if (GUILayout.Button("Crear Enemigo."))
        //{
        //    par.SpawnParametters();
        //}

        ///* if (GUILayout.Button("Eliminar ejercito"))
        // {
        //     enemy.DeleteArmy();
        // }*/


    }
    private void OnSceneGUI()
    {
        _target = (Parametters)target;
        Tools.current = Tool.None;
        //agarre (como en las windows no te deja crear handlers) me pase la misma posicion aca y la iguale,|| si esto(el script)no se usa , podriamos borrarlo(cosa que deje comentada) , pero yo no se bien que es lo que se usa y lo que no 
        //seteá el color 
        Handles.color = Color.red;

        //la distancia en tre las linitas y el point 
        float PointScope = 2;

        //las liñtas
        Handles.DrawLine(_target.transform.position,_target.transform.position + Vector3.right * PointScope);

        Handles.DrawLine(_target.transform.position, _target.transform.position - Vector3.right * PointScope);

        Handles.DrawLine(_target.transform.position, _target.transform.position + Vector3.forward * PointScope);

        Handles.DrawLine(_target.transform.position, _target.transform.position - Vector3.forward * PointScope);

        // los dos circulos
        Handles.DrawSolidDisc(_target.transform.position, Vector3.up, PointScope / 2);
        Handles.DrawWireDisc(_target.transform.position, Vector3.up, PointScope);
    }

}
