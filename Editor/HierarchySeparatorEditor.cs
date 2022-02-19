using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HierarchySeparator))]
[CanEditMultipleObjects]
public class HierarchySeparatorEditor : Editor
{
    //public HierarchySeparator variable;

    private SerializedProperty _outlineSize;
    private SerializedProperty _outlineColor;
    private SerializedProperty _barColor;
    private SerializedProperty _textColor;

    public void OnEnable()
    {
        //variable = target as HierarchySeparator;
        _outlineSize = serializedObject.FindProperty("m_OutlineSize");
        _outlineColor = serializedObject.FindProperty("m_OutlineColor");
        _barColor = serializedObject.FindProperty("m_BarColor");
        _textColor = serializedObject.FindProperty("m_TextColor");
    }
    
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //variable.OutlineSize = EditorGUILayout.IntField("Outline Size", variable.OutlineSize);
        //variable.OutlineColor = EditorGUILayout.ColorField(new GUIContent("Outline Color"), variable.OutlineColor, true, false, false);
        //variable.BarColor = EditorGUILayout.ColorField(new GUIContent("Bar Color"), variable.BarColor, true, false, false);
        //variable.TextColor = EditorGUILayout.ColorField(new GUIContent("Text Color"), variable.TextColor, true, false, false);

        serializedObject.Update();

        EditorGUILayout.PropertyField(_outlineSize);
        EditorGUILayout.PropertyField(_outlineColor);
        EditorGUILayout.PropertyField(_barColor);
        EditorGUILayout.PropertyField(_textColor);

        serializedObject.ApplyModifiedProperties();
    }
}