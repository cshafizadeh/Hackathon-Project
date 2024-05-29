using UnityEngine;
using UnityEditor;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("Window/My Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<MyEditorWindow>("My Editor Window");
    }

    private void OnGUI()
    {
        GUILayout.Label("This is my custom editor window", EditorStyles.boldLabel);

        // Add more GUI controls here
    }
}
