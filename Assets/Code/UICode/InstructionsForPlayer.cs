using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsForPlayer : MonoBehaviour
{

    public GameObject textgo;
    public Canvas canvas;
    //bool jumpbool, timerbool = false;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            canvas.enabled = true;
            textgo.SetActive(true);
        }

    }
    private void OnTriggerStay2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
            canvas.enabled = true;
            textgo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        canvas.enabled = false;
        textgo.SetActive(false);
    }


    private void Update() {

        /*if (jumpbool == true && Input.GetKeyDown(KeyCode.Space)) {
            timerbool = true;

        }

        if (Timer > 0 && timerbool == true) {
            Timer -= Time.deltaTime; // how much time has passed since last update. Eventually it will drop below zero
            if (Timer <= 0) {
                //Timer = 0;
                canvas.enabled = false;
                textgo.SetActive(false);
            }
        }*/
    }

}// class
