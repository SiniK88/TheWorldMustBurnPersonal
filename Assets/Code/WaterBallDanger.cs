using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class WaterBallDanger : MonoBehaviour
{

    Rigidbody2D rb;
    //public float forceup = 10f;

    public float speed = 2f;
    public float height = 4f;
    public Vector3 pos;
    public ParticleSystem splashParticles;

    // use physics and aaforce, with direction and gravity
    // or
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.up * forceup);

        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;

        transform.position = new Vector3(pos.x, newY, pos.z);
        // ondraw gizmos selected piirt‰‰ korkeimman kohdan
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        CreateSplash();
    }

    void CreateSplash() {
        splashParticles.Play();
    }
}
