using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = transform.parent.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.localRotation = transform.parent.rotation;

    }
}
