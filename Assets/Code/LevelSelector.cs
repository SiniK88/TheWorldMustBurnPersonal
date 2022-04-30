using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public MenuAudio menuAudio;

    //public GameObject level1, level2, level3;

    public GameObject[] levelsAvailable;
    public GameObject currentLevel;
    public void LoadLevels( int level) {
        currentLevel = Instantiate(levelsAvailable[level]) as GameObject;
        currentLevel.transform.position = new Vector3(0, 0, 0);
            //Instantiate(levelsAvailable[level], new Vector3(0, 0, 0), Quaternion.identity);
            menuAudio.StopMenuMusic();

    }
    
    public void DestroyLevel() {
        Destroy(currentLevel);
    }

    // public void LoadLevel1() {
    //     Instantiate(level1, new Vector3(0, 0, 0),Quaternion.identity);
    //     menuAudio.StopMenuMusic();
    // }

    // public void LoadLevel2() {
    //     Instantiate(level2, new Vector3(0, 0, 0), Quaternion.identity);
    // }
    // public void LoadLevel3() {
    //     Instantiate(level3, new Vector3(0, 0, 0), Quaternion.identity);
    // }
}
