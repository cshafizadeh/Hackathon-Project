using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeMaterialsShader : MonoBehaviour
{
    [MenuItem("Tools/Change Shader of All Materials")]
    public static void ChangeShader()
    {
        
        Shader newShader = Shader.Find("PSX/Vertex Lit Cutout"); // Change to your desired shader path

        if (newShader == null)
        {
            Debug.LogError("Shader not found!");
            return;
        }

        // Get all materials in the project
        string[] materialGuids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in materialGuids)
        {
            string materialPath = AssetDatabase.GUIDToAssetPath(guid);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

            if (material != null)
            {
                Undo.RecordObject(material, "Change Shader");
                material.shader = newShader;
                EditorUtility.SetDirty(material);
            }
        }
        AssetDatabase.SaveAssets();
        Debug.Log("All materials have been updated to use the new shader.");
    }
}
