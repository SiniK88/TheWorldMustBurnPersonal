using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionColliding : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Invoke("DestroySpark", lifeTime);
    }

    void DestroySpark() {
        // effect
        Destroy(gameObject);
    }

}
