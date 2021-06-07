using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupText : MonoBehaviour
{
    Text powerup;
    GameManager gm;
    void Start()
    {
        powerup = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        powerup.text = "Powerup " +  gm.State + "  " + gm.powerupTimer.ToString("00");
    }
}
