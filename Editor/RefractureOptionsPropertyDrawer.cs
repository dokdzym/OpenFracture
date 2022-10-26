using UnityEditor;
using UnityEngine;

// IngredientDrawerUIE
[CustomPropertyDrawer(typeof(RefractureOptions))]
public class RefractureOptionsPropertyDrawer : PropertyDrawer
{   
    private static bool foldout = true;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var enableRefracturing = property.FindPropertyRelative("enableRefracturing");
        var maxRefractureCount = property.FindPropertyRelative("maxRefractureCount");
        var invokeCallbacks = property.FindPropertyRelative("invokeCallbacks");

        EditorGUI.indentLevel = 0;
//        foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, label);
        foldout = EditorGUILayout.BeginToggleGroup("RefractureOptionsPropertyDrawer", foldout);

        if (foldout)
        {
            EditorGUI.indentLevel = 1;
            if(enableRefracturing != null)
                EditorGUILayout.PropertyField(enableRefracturing, new GUIContent("Enabled"));
            if(invokeCallbacks != null)
                EditorGUILayout.PropertyField(invokeCallbacks, new GUIContent("Invoke Callbacks"));
            if(maxRefractureCount != null)
                EditorGUILayout.PropertyField(maxRefractureCount, new GUIContent("Max # of Refractures"));
        }

//        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.EndToggleGroup();
        EditorGUI.indentLevel = 0;
    }
    
    // Hack to prevent extra space at top of property drawer. This is due to using EditorGUILayout
    // in OnGUI, but I don't want to have to manually specify control sizes
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return 0; }
}