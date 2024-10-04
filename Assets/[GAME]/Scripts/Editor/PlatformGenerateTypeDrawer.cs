using _GAME_.Scripts.GlobalVariables;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PlatformGenerateType))]
public class PlatformGenerateTypeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);

        position = new Rect(position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, position.height);

        string[] enumNames = property.enumNames;
        int selectedIndex = property.enumValueIndex;

        float buttonWidth = position.width / enumNames.Length;

        for (int i = 0; i < enumNames.Length; i++)
        {
            Rect buttonRect = new Rect(position.x + i * buttonWidth, position.y, buttonWidth, position.height);

            if (GUI.Toggle(buttonRect, selectedIndex == i, enumNames[i], "Button"))
            {
                selectedIndex = i;
            }
        }

        if (property.enumValueIndex != selectedIndex)
        {
            property.enumValueIndex = selectedIndex;
        }
    }
}