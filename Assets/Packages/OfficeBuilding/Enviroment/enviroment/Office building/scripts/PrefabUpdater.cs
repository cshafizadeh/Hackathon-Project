using UnityEditor;
using UnityEngine;

public class NestedPrefabUpdater : EditorWindow
{
    public GameObject targetPrefab;
    public Material outlineMaterial;

    [MenuItem("Tools/Update Nested Prefab Instances")]
    public static void ShowWindow()
    {
        GetWindow<NestedPrefabUpdater>("Update Nested Prefab Instances");
    }

    void OnGUI()
    {
        GUILayout.Label("Update Nested Prefab Instances", EditorStyles.boldLabel);
        targetPrefab = (GameObject)EditorGUILayout.ObjectField("Target Prefab", targetPrefab, typeof(GameObject), false);
        outlineMaterial = (Material)EditorGUILayout.ObjectField("Outline Material", outlineMaterial, typeof(Material), false);

        if (GUILayout.Button("Update Instances"))
        {
            UpdatePrefabInstances();
        }
    }

    void UpdatePrefabInstances()
    {
        if (targetPrefab == null || outlineMaterial == null)
        {
            Debug.LogError("Target Prefab and Outline Material must be set.");
            return;
        }

        string prefabPath = AssetDatabase.GetAssetPath(targetPrefab);
        GameObject[] allPrefabs = AssetDatabase.LoadAllAssetsAtPath(prefabPath) as GameObject[];

        foreach (GameObject prefab in allPrefabs)
        {
            UpdatePrefabInScene(prefab);
        }

        Debug.Log("All instances updated.");
    }

    void UpdatePrefabInScene(GameObject prefab)
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(obj) == AssetDatabase.GetAssetPath(prefab))
            {
                Collectible collectible = obj.GetComponent<Collectible>();
                if (collectible == null)
                {
                    collectible = obj.AddComponent<Collectible>();
                }
                collectible.outlineMaterial = outlineMaterial;

                Debug.Log("Updated: " + obj.name);
            }
        }
    }
}
