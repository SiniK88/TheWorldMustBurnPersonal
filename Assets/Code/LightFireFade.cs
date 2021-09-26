using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightFireFade : MonoBehaviour
{
    Light2D light2d;
    [SerializeField] float speed = 3f;
    [SerializeField] float min = 0.4f;
    [SerializeField] float max = 3f;
    float counter = 0f;
    void Start()
    {
        light2d = GetComponent<Light2D>();
        Destroy(gameObject, 3.8f);
    }

    void Update()
    {
        counter += Time.deltaTime;
        light2d.pointLightOuterRadius = Mathf.Lerp(max, min, counter/speed);

        light2d.intensity = Mathf.Lerp(1, 0.2f, counter / speed);

    }
}
