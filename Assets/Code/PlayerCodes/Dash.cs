using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    [Range(1f, 30f)] float dashSpeed;

    [SerializeField]
    [Range(0f, 2f)] float dashTime;

    public float startDashTime;
    private int direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

   
    void Update()
    {
        
        if(direction == 0) {
            if (Input.GetKeyDown(KeyCode.W) ) {
                direction = 1;
            } else if(Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) {
                direction = 2;
            } else if (Input.GetKeyDown(KeyCode.W) ) {
                direction = 3;
            } else if(Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
                direction = 4;
            }
        } else {
            if (dashTime <= 0) {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else {
                dashTime -= Time.deltaTime;
                if (direction == 1) {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if(direction == 2) {
                    rb.velocity = Vector2.right * dashSpeed;
                } else if(direction == 3){
                    rb.velocity = Vector2.up * dashSpeed;
                } else if(direction == 4) {
                    rb.velocity = Vector2.down * dashSpeed;
                }
                } 
            }

    }
}
