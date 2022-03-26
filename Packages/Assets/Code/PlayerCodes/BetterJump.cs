using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    public float fallMultiplayer = 2.5f;
    public float lowJumpMultiplayer = 2f;

    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // velocity < 0 -> we are falling and we apply fallmultiplier
    // -1 because some unity physics stuff
    // else, kun liikutaa ylöspäin ja ei paineta enää "jump" nappia pohjassa
    private void Update() {
        if(rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime; 
        } else if( rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer - 1) * Time.deltaTime;
        }
    }


}
