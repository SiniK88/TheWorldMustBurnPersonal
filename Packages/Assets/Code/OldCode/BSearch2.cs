using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSearch2 : MonoBehaviour
{
    [Range(1, 16)] public int haettavaNumero;
    int a = 0, b, n, x;
    public int[] t = new int[10];

    void Start() {
        n = t.Length;
        b = n;

        t[0] = 1;
        t[1] = 2;
        t[2] = 3;
        t[3] = 4;
        t[4] = 5;
        t[5] = 6;
        t[6] = 7;
        t[7] = 8;
        t[8] = 9;
        t[9] = 11;
    }

    void Update() {
        x = haettavaNumero;

        if (Input.GetKeyDown(KeyCode.Space)) {
            while (a <= b) {
                int k = (a + b) / 2;
                if (t[k] == x) {
                    print("Haettava numero " + x + " löytyi listan kohdasta " + k + " Aikaa kului " + Time.deltaTime + " sekunttia");
                    //Resetoidaan arvot a ja b
                    a = 0;
                    b = n;
                    break; // Stoppaa looppi löydön jälkeen
                }
                if (t[k] > x) {
                    b = k - 1;
                    print("Ei löytöä, minuustetaan b " + k + " -1");
                } else {
                    a = k + 1;
                    print("Ei löytöä plussataan a " + k + " +1");
                }
            }
        }
    }
}
