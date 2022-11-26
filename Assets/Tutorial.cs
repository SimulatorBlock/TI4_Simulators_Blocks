using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private GameObject tutorial;

    private void Start()
    {
        tutorial.SetActive(false);
    }

    public void EnableTutorial(bool state)
    {
        tutorial.SetActive(state);
    }
}
