using UnityEngine;
using UnityEditor;

public class CollectibleEditor : EditorWindow
{
    public Material outlineMaterial; // Reference to the outline material

    [MenuItem("Window/Collectible Editor")]
    public static void ShowWindow()
    {
        GetWindow<CollectibleEditor>("Collectible Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("Add Collectible Script and Outline Shader", EditorStyles.boldLabel);

        outlineMaterial = (Material)EditorGUILayout.ObjectField("Outline Material", outlineMaterial, typeof(Material), false);

        if (GUILayout.Button("Apply to All Collectibles"))
        {
            ApplyCollectibleScript();
        }
    }

    void ApplyCollectibleScript()
    {
        if (outlineMaterial == null)
        {
            Debug.LogError("Outline Material must be assigned!");
            return;
        }

        // Find all game objects tagged as "Collectible"
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject collectible in collectibles)
        {
            // Add the Collectible script if it doesn't already exist
            if (collectible.GetComponent<Collectible>() == null)
            {
                Collectible collectibleScript = collectible.AddComponent<Collectible>();
                collectibleScript.outlineMaterial = outlineMaterial;

                Debug.Log($"Collectible script added to {collectible.name}");
            }
        }

        Debug.Log("Collectible script and outline material applied to all collectibles.");
    }
}