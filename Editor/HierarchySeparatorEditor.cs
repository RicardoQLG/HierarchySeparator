using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HierarchySeparator))]
[CanEditMultipleObjects]
public class HierarchySeparatorEditor : Editor
{
  public HierarchySeparator variable;

  public void OnEnable()
  {
    variable = target as HierarchySeparator;
  }

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    variable.BarColor = EditorGUILayout.ColorField(new GUIContent("Color"), variable.BarColor, true, false, false);
	  variable.TextColor = EditorGUILayout.ColorField(new GUIContent("Color"), variable.TextColor, true, false, false);
  }
}