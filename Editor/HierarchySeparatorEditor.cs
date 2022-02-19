using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HierarchySparator))]
public class HierarchySparatorEditor : Editor
{
  public HierarchySparator variable;

  public void OnEnable()
  {
    variable = target as HierarchySparator;
  }

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    variable.BarColor = EditorGUILayout.ColorField(new GUIContent("Color"), variable.BarColor, true, false, false);
  }
}