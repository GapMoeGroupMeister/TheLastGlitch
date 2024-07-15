using Codice.Client.BaseCommands.Merge.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

[CustomEditor(typeof(UISet))]
public class CustomUIInfo : Editor
{
    private SerializedProperty _uiTypeProp;
    private SerializedProperty _moveSpeedProp;
    private SerializedProperty _startPositionProp;
    private SerializedProperty _endPositionProp;

    private void OnEnable()
    {
        _uiTypeProp = serializedObject.FindProperty("uiSet");
        _moveSpeedProp = serializedObject.FindProperty("moveSpeed");
        _startPositionProp = serializedObject.FindProperty("startPosition");
        _endPositionProp = serializedObject.FindProperty("endPosition");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); //디스크에 있는 내용을 업데이트해서 가져온다
        //base.OnInspectorGUI();

        EditorGUILayout.PropertyField(_uiTypeProp);
        if (_uiTypeProp.GetEnumValue<UIEnum>() == UIEnum.MoveUI)
        {
            EditorGUILayout.PropertyField(_moveSpeedProp);

            EditorGUILayout.LabelField("Move Position");

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.PropertyField(_startPositionProp, GUIContent.none);
                EditorGUILayout.PropertyField(_endPositionProp, GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }

        

        serializedObject.ApplyModifiedProperties();
    }
}
