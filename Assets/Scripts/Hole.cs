using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]LayerMask ballLayer;
    [SerializeField] float range;
    [HideInInspector] public bool isIn;

    void Update()
    {
        isIn = Physics2D.OverlapCircle(transform.position,range,ballLayer);
    }
}
