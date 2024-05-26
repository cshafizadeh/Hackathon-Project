using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public int pointValue = 10; // Points awarded for collecting this item
    public float highlightDistance = 5f; // Distance within which the item is highlighted
    public Material outlineMaterial; // Outline material
    private List<Material[]> originalMaterials = new List<Material[]>(); // Original materials of the item
    private List<Renderer> renderers = new List<Renderer>();
    private bool isHighlighted = false;
    private GameObject player;
    private PlayerPoints playerPoints; // Reference to the player's points script

    void Start()
    {
        // Get all Renderer components from the children
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in childRenderers)
        {
            renderers.Add(rend);
            originalMaterials.Add(rend.materials);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        playerPoints = player.GetComponent<PlayerPoints>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Highlight the item if the player is within highlight distance
        if (distanceToPlayer <= highlightDistance)
        {
            if (!isHighlighted)
            {
                HighlightItem(true);
            }

            // Check if the player's crosshair is over the item and they press "E" or click
            if (IsPlayerLookingAtItem() && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
            {
                CollectItem();
            }
        }
        else
        {
            if (isHighlighted)
            {
                HighlightItem(false);
            }
        }
    }

    void HighlightItem(bool highlight)
    {
        if (highlight)
        {
            foreach (Renderer rend in renderers)
            {
                Material[] mats = new Material[rend.materials.Length + 1];
                for (int i = 0; i < rend.materials.Length; i++)
                {
                    mats[i] = rend.materials[i];
                }
                mats[rend.materials.Length] = outlineMaterial;
                rend.materials = mats;
            }
            isHighlighted = true;
        }
        else
        {
            for (int i = 0; i < renderers.Count; i++)
            {
                renderers[i].materials = originalMaterials[i];
            }
            isHighlighted = false;
        }
    }

    bool IsPlayerLookingAtItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, highlightDistance))
        {
            return hit.transform == transform;
        }

        return false;
    }

    void CollectItem()
    {
        playerPoints.AddPoints(pointValue);
        Destroy(gameObject);
    }
}
