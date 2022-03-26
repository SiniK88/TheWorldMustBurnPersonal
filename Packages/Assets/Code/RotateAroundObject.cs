using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public GameObject gobject;
    public Vector3 axis;

    [Header("Angle covered per update")]
    public float angle; 


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gobject.transform.position, axis, angle);
    }
}
