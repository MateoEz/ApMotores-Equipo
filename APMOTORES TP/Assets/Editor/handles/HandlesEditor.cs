using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HandlesTransform))]
public class HandlesEditor : Editor
{
    HandlesTransform _target;


    private void OnEnable()
    {
        _target = (HandlesTransform)target;
    }

    private void OnSceneGUI()
    {
        if (_target.soldier0 && _target.soldier1 && _target.soldierGreen && _target.soldierRed)
        {
            _target.soldier0.position = Handles.PositionHandle(_target.soldier0.position,_target.soldier0.rotation);
            _target.soldier1.position = Handles.PositionHandle(_target.soldier1.position, _target.soldier1.rotation);
            _target.soldierGreen.position = Handles.PositionHandle(_target.soldierGreen.position, _target.soldierGreen.rotation);
            _target.soldierRed.position = Handles.PositionHandle(_target.soldierRed.position, _target.soldierRed.rotation);


            Tools.current = Tool.None;

            _target.transform.rotation = Handles.RotationHandle(_target.transform.rotation, _target.transform.position);
        }
    }
}
