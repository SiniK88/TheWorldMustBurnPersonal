using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLoops : MonoBehaviour
{
    LevelEnd levelEnd;
    int levelNum;

    void Start()
    {
        levelEnd = FindObjectOfType<LevelEnd>();
        levelNum = levelEnd.LevelNumber;

        if(levelNum == 1) {
            AudioFW.PlayLoop("Level1Forest");
        }
        if(levelNum == 2) {
            AudioFW.PlayLoop("Level2Cave");
        }
        if (levelNum == 3) {
            AudioFW.PlayLoop("Level3Forest");
        }
    }

    public void StopLevelMusic() {
        if (levelNum == 1) {
            AudioFW.StopLoop("Level1Forest");
        }
        if (levelNum == 2) {
            AudioFW.StopLoop("Level2Cave");
        }
        if (levelNum == 3) {
            AudioFW.StopLoop("Level3Forest");
        }
    }



}
