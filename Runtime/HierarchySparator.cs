using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchySparator : MonoBehaviour
{
  [HideInInspector]
  [SerializeField]
  private Color m_BarColor;
  public Color BarColor {
    get {
      if(m_BarColor == null) m_BarColor = Color.black;
      return m_BarColor;
    }
    set {
      value.a = 1f;
      m_BarColor = value;
    }
  }

  static HierarchySparator()
  {
    EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
  }

  [MenuItem("GameObject/Separator")]
  public static void CreateSeparator(MenuCommand menuCommand)
  {
    GameObject separator = new GameObject("Separator");
    separator.AddComponent<HierarchySparator>();
    GameObjectUtility.SetParentAndAlign(separator, menuCommand.context as GameObject);
    Undo.RegisterCreatedObjectUndo(separator, "Create " + separator.name);
    Selection.activeObject = separator;
  }

  static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
  {
    GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

    if (gameObject == null) return;
    if (!gameObject.TryGetComponent(out HierarchySparator hierarchy)) return;

    Color color = hierarchy.BarColor;

    EditorGUI.DrawRect(selectionRect, color);
    EditorGUI.DropShadowLabel(selectionRect, $"{gameObject.name.ToUpperInvariant()}");
  }
}