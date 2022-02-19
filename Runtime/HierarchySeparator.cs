using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchySeparator : MonoBehaviour
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
  
  [HideInInspector]
  [SerializeField]
  private Color m_TextColor;
  public Color TextColor {
    get {
      if(m_TextColor == null) m_TextColor = Color.white;
      return m_TextColor;
    }
    set {
      value.a = 1f;
      m_TextColor = value;
    }
  }

  static HierarchySeparator()
  {
    EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
  }

  [MenuItem("GameObject/Separator")]
  public static void CreateSeparator(MenuCommand menuCommand)
  {
    GameObject separator = new GameObject("Separator");
    separator.AddComponent<HierarchySeparator>();
    GameObjectUtility.SetParentAndAlign(separator, menuCommand.context as GameObject);
    Undo.RegisterCreatedObjectUndo(separator, "Create " + separator.name);
    Selection.activeObject = separator;
  }

  static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
  {
    GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

    if (gameObject == null) return;
    if (!gameObject.TryGetComponent(out HierarchySeparator hierarchy)) return;

    Color color = hierarchy.BarColor;
	GuiStyle guiStyle = new GuiStyle();
	guiStyle.fontStyle = FontStyle.Bold;
    guiStyle.normal.textColor = hierarchy.TextColor;
	guiStyle.alignment = TextAnchor.MiddleCenter;

    EditorGUI.DrawRect(selectionRect, color);
    EditorGUI.DropShadowLabel(selectionRect, $"{gameObject.name.ToUpperInvariant()}", guiStyle);
  }
}