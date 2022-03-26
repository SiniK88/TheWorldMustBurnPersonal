using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{

    public float moveSpeed = 12;
    public Vector3 moveVector;
    public Camera mainCamera;

    Vector3 cameraPos;

    Transform t;
    public bool isTouching;
    Rigidbody2D rigidBody;
    float moveX;
    float moveY;

    public float jumpPower;
    void Start() {
        t = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody == null)
            Debug.LogError("RigidBody could not be found.");

        if (mainCamera) {
            cameraPos = mainCamera.transform.position;
        }
    }

    void Update() {
        if (isTouching && Input.GetKeyDown(KeyCode.Space)) { //jump
            rigidBody.AddForce(new Vector3(0, jumpPower, 0) * 50);
            isTouching = false;
        }

        PlayerMovement();
        // Camera follow
        if (mainCamera) {
            mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);

        }
    }

    void PlayerMovement() {
        moveX = Input.GetAxis("Horizontal");
        //moveY = Input.GetAxis("Vertical");
        moveVector = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector, Space.Self);

    }


    void OnCollisionStay2D() {
        print(" koskeeko se");
        isTouching = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("koskee");
        isTouching = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        print("Ei koske");
        isTouching = false;
    }



}
