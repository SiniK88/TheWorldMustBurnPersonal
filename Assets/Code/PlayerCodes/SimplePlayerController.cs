using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour {

    Rigidbody2D rb;
    [Range(1f, 10f)] public float jumpForce = 5f;
    [Range(1f, 10f)] public float groundFrictionWhenNoInput = 5f;
    [Range(1f, 10f)] public float airFrictionWhenNoInput = 5f;
    [Range(1f, 30f)] public float horizontal = 5f;
    [Range(1f, 30f)] public float horizontalMaxSpeed = 5f;
    public int extraJumps = 1;
    int jumpcCount = 0;

    public bool grounded;
    bool jump;
    float deadzone = 0.1f;
    float bonusGravity = 5f;

    public Camera mainCamera;
    Vector3 cameraPos;
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera) {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Jump") && grounded) {
            jump = true;
        }

        if (mainCamera) {
            mainCamera.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, cameraPos.z);

        }

    }

    private void FixedUpdate() {
        var horizontalInput = Vector2.right * Input.GetAxis("Horizontal");
        var newVelocity = rb.velocity + horizontalInput * horizontal * Time.deltaTime;
        newVelocity.x = Mathf.Lerp(newVelocity.x, 0, Time.deltaTime * (grounded ? groundFrictionWhenNoInput : airFrictionWhenNoInput));

        if (jump) {
            newVelocity.y = jumpForce;
            jump = false;
        }
        rb.velocity = newVelocity;

    }



}
