using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    float Timer = 1f; // 
    public bool birth = false;
    public GameObject player;
    GameManager gm;
    //RayCastPlayer playerC;
    private void Start() {
        gm = FindObjectOfType<GameManager>();
        gm.State = PowerupType.None;
        //playerC = FindObjectOfType<RayCastPlayer>();
    }

    void Update()
    {
        if (Timer > 0) {
            Timer -= Time.deltaTime; // how much time has passed since last update. Eventually it will drop below zero

            if (Timer <= 0) {
                //player.SetActive(true);
                Timer = 0;
                player.GetComponent<RayCastPlayer>().enabled = true;
                //player.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

    }
}
