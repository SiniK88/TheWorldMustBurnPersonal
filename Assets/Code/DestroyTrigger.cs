using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player")
            print("osui");
            Destroy(gameObject);
    }
}
