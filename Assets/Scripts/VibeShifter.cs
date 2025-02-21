using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeShifter : MonoBehaviour
{
    //private variables
    float density;
    bool isMakingNormal;
    bool isMakingScary;
    Camera cam;
    Color currentFogColor;

    [Header("ColorValues")]
    [SerializeField] Color regularFog;
    [SerializeField] Color scaryFog;



    // Start is called before the first frame update
    void Start()
    {
        density = 0.015f;
        currentFogColor = regularFog;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMakingScary && !isMakingNormal)
        {
            density = Mathf.Lerp(density, 0.04f, 0.001f);
            currentFogColor = Color.Lerp(currentFogColor, scaryFog, 0.001f);

            RenderSettings.fogColor = currentFogColor;
            cam.backgroundColor = currentFogColor;
            RenderSettings.fogDensity = density;

        }
        if (isMakingNormal && !isMakingScary)
        {
            density = Mathf.Lerp(density, 0.015f, 0.001f);
            currentFogColor = Color.Lerp(currentFogColor, regularFog, 0.001f);

            RenderSettings.fogColor = currentFogColor;
            cam.backgroundColor = currentFogColor;
            RenderSettings.fogDensity = density;
        }

        if ((density == 0.015f || density == 0.025f) && (RenderSettings.fogColor == regularFog || RenderSettings.fogColor == scaryFog))
        {
            isMakingNormal = false;
            isMakingScary = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isMakingScary = true;
        isMakingNormal = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isMakingScary = false;
        isMakingNormal = true;
    }
}
