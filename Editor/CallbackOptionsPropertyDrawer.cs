using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CallbackOptions))]
public class CallbackOptionsPropertyDrawer : PropertyDrawer
{   
    private static bool foldout = true;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
//        foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, label);
        foldout = EditorGUILayout.BeginToggleGroup("CallbackOptionsPropertyDrawer", foldout);
        
//        if (foldout)
        {
            var prop1 = property.FindPropertyRelative("onFracture");
            if(prop1 != null)
                EditorGUILayout.PropertyField(prop1);
            
            var prop2 = property.FindPropertyRelative("onCompleted");
            if(prop2 != null)
                EditorGUILayout.PropertyField(property.FindPropertyRelative("onCompleted"));
            else
                Logger.LogErrorF("cannot find onCompleted");
        }
        
        EditorGUILayout.EndToggleGroup();
//        EditorGUILayout.EndFoldoutHeaderGroup();
    }
    
    // Hack to prevent extra space at top of property drawer. This is due to using EditorGUILayout
    // in OnGUI, but I don't want to have to manually specify control sizes
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return 0; }
}