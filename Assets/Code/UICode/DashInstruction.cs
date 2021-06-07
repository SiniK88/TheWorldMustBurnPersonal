using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashInstruction : MonoBehaviour
{
    public GameObject textgo;
    public Canvas canvas;
    bool jumpbool, timerbool = false;
    public float Timer = 2f;
    public GameObject player;
    public bool dash;
    void Start() {
        //canvas = GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player");
        dash = player.GetComponent<RayCastPlayer>().dash;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && jumpbool == false) {
            print("something happens");
            canvas.enabled = true;
            textgo.SetActive(true);
            jumpbool = true;
        }

    }


    private void Update() {
        dash = player.GetComponent<RayCastPlayer>().dash;
        if (jumpbool == true && dash == true) {
            timerbool = true;

        }

        if (Timer > 0 && timerbool == true) {
            Timer -= Time.deltaTime; // how much time has passed since last update. Eventually it will drop below zero
            if (Timer <= 0) {
                //Timer = 0;
                canvas.enabled = false;
                textgo.SetActive(false);
            }
        }
    }
}
