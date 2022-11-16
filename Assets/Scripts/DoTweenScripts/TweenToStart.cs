using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TweenToStart : MonoBehaviour
{
    [SerializeField] private List<ModelsTweenToStart> modelsTweenToStarts;
    private int randomStart;
    private void Start()
    {
        randomStart = Random.Range(0, 2);

        foreach (var models in modelsTweenToStarts)
            models.DoTween(randomStart);
    }
    private void Update()
    {
        if(!Input.GetKeyDown(KeyCode.R)) return;
        randomStart = Random.Range(0, 2);

        foreach (var models in modelsTweenToStarts)
            models.DoTween(randomStart);
    }
}