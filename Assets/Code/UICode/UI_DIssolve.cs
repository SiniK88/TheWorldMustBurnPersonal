using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI_DIssolve : MonoBehaviour
{
    Material dissolveMat;
    
    float fade = 1f;
    bool isDissolving = false;

    void Start()
    {
        dissolveMat = GetComponent<Image>().material;
    }

    private void Update() {
        if (isDissolving == true) {
            DissolveFunctio();
        }
    }

        public void DissolveFunctio() {
            print("klicked");
            fade -= Time.deltaTime;

            if (fade <= 0f) {
                print("fade happened");
                isDissolving = false;
                fade = 0;
            }

            dissolveMat.SetFloat("_Dissolve", fade);
    }

    public void KlickDissolve(){
            isDissolving = true;
    }


}
