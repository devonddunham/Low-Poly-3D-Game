using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxGenerator : MonoBehaviour
{

    public Material[] skyBoxes;

    // Start is called before the first frame update
    void Start()
    {
        var randomSkybox = skyBoxes[Random.Range(0, skyBoxes.Length)];
        RenderSettings.skybox = randomSkybox;
    }
}
