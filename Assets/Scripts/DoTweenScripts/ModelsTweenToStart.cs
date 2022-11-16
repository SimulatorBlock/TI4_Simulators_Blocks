using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class ModelsTweenToStart : MonoBehaviour
{
    private Vector3 initialAndLastPos;
    private Vector3 middlePos;

    private Vector3 initialAndLastScale;
    private Vector3 middleScale;

    private void Awake()
    {
        initialAndLastPos = transform.position;
        initialAndLastScale = transform.localScale;
    }

    public void DoTween(int randomStart)
    {
        if (randomStart == 0)
        {
            middlePos = new Vector3(initialAndLastPos.x, Random.Range(50, 401), initialAndLastPos.z);

            transform.position = middlePos;

            transform.DOMove(new Vector3(initialAndLastPos.x, initialAndLastPos.y, initialAndLastPos.z), 1);
        }
        else
        {
            middleScale = new Vector3(0, 0, 0);

            transform.localScale = middleScale;

            transform.DOScale(new Vector3(initialAndLastScale.x, initialAndLastScale.y, initialAndLastScale.z), 1);
        }
    }
}