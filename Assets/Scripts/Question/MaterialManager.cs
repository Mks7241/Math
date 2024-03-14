using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] wrongBlocks1;
    public GameObject[] wrongBlocks2;
    public GameObject[] correctBlocks2;
    Material randomMaterial;
    public float transparency = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        ApplyRandomMaterial();
        ApplyRandomMaterialToBlocks(wrongBlocks1);
        ApplyRandomMaterialToBlocks(wrongBlocks2);
        ApplyRandomMaterialToBlocks(correctBlocks2);
    }

    void ApplyRandomMaterialToBlocks(GameObject[] blocks)
    {
        //Material randomMaterial = materials[Random.Range(0, materials.Length)];
        foreach (GameObject block in blocks)
        {
            Renderer[] renderers = block.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material = randomMaterial;
                
            }
        }
    }
    public void ApplyRandomMaterial()
    {
        randomMaterial = materials[Random.Range(0, materials.Length)];
        randomMaterial.SetFloat("_Mode", 3); // Set material render mode to transparent

        Color color = randomMaterial.color;
        color.a = transparency; // Set transparency of the material
        randomMaterial.color = color;
    }
}
