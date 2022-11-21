using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMap : MonoBehaviour
{
    [SerializeField] GameObject[] maps;
    int randomMap;

    void Start()    
    {
        randomMap = Random.Range(0, maps.Length);

        foreach(GameObject map in maps)
            map.SetActive(false);

        maps[randomMap].SetActive(true);

        if(randomMap == 0)
            SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox0);
        else
            SkyboxScene.Instance.SetSkyBox(SkyBoxNames.skyboxName.SkyBox19);
    }
}
