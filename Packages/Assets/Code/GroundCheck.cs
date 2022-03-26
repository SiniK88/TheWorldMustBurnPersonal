using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    SimplePlayerControllerDoubleJump player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SimplePlayerControllerDoubleJump>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        player.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        player.grounded = false;
    }
}
