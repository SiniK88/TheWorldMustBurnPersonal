using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{


    public GameObject level1, level2, level3;

    public void LoadLevel1() {
        Instantiate(level1, new Vector3(0, 0, 0),Quaternion.identity);
    }

    public void LoadLevel2() {
        Instantiate(level2, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void LoadLevel3() {
        Instantiate(level3, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
