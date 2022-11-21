using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxNames
{
    public enum skyboxName
    {
        SkyBox0,
        SkyBox1,
        SkyBox2,
        SkyBox3,
        SkyBox4,
        SkyBox5,
        SkyBox6,
        SkyBox7,
        SkyBox8,
        SkyBox9,
        SkyBox10,
        SkyBox11,
        SkyBox12,
        SkyBox13,
        SkyBox14,
        SkyBox15,
        SkyBox16,
        SkyBox17,
        SkyBox18,
        SkyBox19,
    }
}
public class SkyboxScene : MonoBehaviour
{
    public static SkyboxScene Instance;
    private void Awake()
    {
        if(Instance) {Destroy(gameObject); return;}
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        RenderSettings.skybox = skyboxMaterial[(int)name];
    }
    
    [SerializeField] private Material[] skyboxMaterial;
    [SerializeField] private SkyBoxNames.skyboxName name;
    public void SetSkyBox(SkyBoxNames.skyboxName nameOf)
    {
        RenderSettings.skybox = skyboxMaterial[(int)nameOf];
    }
}
