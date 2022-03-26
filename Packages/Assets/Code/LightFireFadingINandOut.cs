using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightFireFadingINandOut : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2d;

    [SerializeField] float radMin = 4f;
    [SerializeField] float radMax = 5f;
    [SerializeField] float speed = 0.4f;


    FireManager fireManager;

    private void Start() {
        fireManager = GameObject.FindGameObjectWithTag("FireManager").GetComponent<FireManager>();
    }

    void Update()
    {

        float newRad = Mathf.Lerp(radMin,radMax, Mathf.PingPong(Time.time * speed, 1));
        light2d.pointLightOuterRadius = newRad;

    }

 
}
