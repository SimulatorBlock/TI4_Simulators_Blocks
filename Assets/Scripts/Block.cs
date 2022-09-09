using System;
using UnityEngine;

[Serializable]
public class Block : MonoBehaviour
{
    [SerializeField] private int mass;
    public int Mass => mass;
}
