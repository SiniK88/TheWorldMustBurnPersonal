using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public ParticleSystem rain;
    public float rainCycle = 5;
    public float timer = 0;
    public bool rainBool = false;

    PlayerHealth playerHealth;

    private void Start() {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnParticleCollision(GameObject other) {
        if (other.gameObject.CompareTag("Water")) {
            print("rain hit the player");
            playerHealth.Damaged(1);
        }

    }

    private void Update() {
        timer += Time.deltaTime;
        while(timer > rainCycle) {
            if (rainBool == true) {
                rain.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                rainBool = false;
            } else {
                rain.Play();
                rainBool = true;
            }
            timer -= rainCycle;

        }
    }

}
