using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxNames
{
    public enum skyboxName
    {
        SkyBox0 = 0,
        SkyBox1 = 1,
        SkyBox2 = 2,
        SkyBox3 = 3,
        SkyBox4 = 4,
        SkyBox5 = 5,
        SkyBox6 = 6,
        SkyBox7 = 7,
        SkyBox8 = 8,
        SkyBox9 = 9,
        SkyBox10 = 10,
        SkyBox11 = 11,
        SkyBox12 = 12,
        SkyBox13 = 13,
        SkyBox14 = 14,
        SkyBox15 = 15,
        SkyBox16 = 16,
        SkyBox17 = 17,
        SkyBox18 = 18,
        SkyBox19 = 19,
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
    }
    
    [SerializeField] private Material[] skyboxMaterial;
    [SerializeField] private SkyBoxNames.skyboxName name;
    private void Start()
    {
        RenderSettings.skybox = skyboxMaterial[(int)name];
    }

    public void SetSkyBox(SkyBoxNames.skyboxName nameOf)
    {
        RenderSettings.skybox = skyboxMaterial[(int)nameOf];
    }
}
