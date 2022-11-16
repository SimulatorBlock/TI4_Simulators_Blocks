using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct VFXs
{
    public string name;
    public GameObject vfxGameObj;
    public ParticleSystem vfxParticleSys;
}
public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    private void Awake()
    {
        if(Instance) {Destroy(gameObject); return;}
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private VFXs[] vfXsList;
    
    
    //Metodos para ativar/desativar
    //Metodos para mudar propriedades e tempo seila..

    public void EnableVFX(string vfxName)
    {
        VFXs vfx = Array.Find(vfXsList, vFXs =>  vFXs.name == vfxName);

        foreach (var var in vfXsList)
        {
            if(var.name == vfxName)
                vfx.vfxGameObj.SetActive(true);
        }
        //vfx.vfxParticleSys.seila;
    }
}
