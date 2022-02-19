using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchySeparator : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Color m_OutlineColor = Color.black;
    public Color OutlineColor
    {
        get => m_OutlineColor;
        set
        {
            value.a = 1f;
            m_OutlineColor = value;
        }
    }

    [HideInInspector]
    [SerializeField]
    private Color m_BarColor = Color.black;
    public Color BarColor
    {
        get => m_BarColor;
        set
        {
            value.a = 1f;
            m_BarColor = value;
        }
    }

    [HideInInspector]
    [SerializeField]
    private Color m_TextColor = Color.white;
    public Color TextColor
    {
        get => m_TextColor;
        set
        {
            value.a = 1f;
            m_TextColor = value;
        }
    }

    [HideInInspector]
    [SerializeField]
    private int m_OutlineSize = 0;
    public int OutlineSize
    {
        get => m_OutlineSize;
        set
        {
            m_OutlineSize = value;
        }
    }

    static HierarchySeparator()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }
    
    [MenuItem("GameObject/Separator", false, 30)]
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

        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = hierarchy.TextColor;
        guiStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUI.DrawRect(selectionRect, hierarchy.OutlineColor);
        EditorGUI.DrawRect(new Rect(selectionRect.x + hierarchy.OutlineSize, selectionRect.y + hierarchy.OutlineSize, selectionRect.width - (hierarchy.OutlineSize * 2), selectionRect.height - (hierarchy.OutlineSize * 2)), hierarchy.BarColor);
        EditorGUI.DropShadowLabel(selectionRect, $"{gameObject.name.ToUpperInvariant()}", guiStyle);
    }
}