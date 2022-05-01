using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public MenuAudio menuAudio;

    [SerializeField] GameObject[] levels;
    MovingOnLevelsMap levelsScript;

    public GameObject[] levelsAvailable;
    public GameObject currentLevel;

    public int levelNum;

    void Start(){
        levels = GameObject.FindGameObjectsWithTag("Level");
    }

        private void Update(){
        if(Input.GetKeyDown(KeyCode.N)){
            print(" something"); 
            print( "current level number is " + levelNum);
            FindCurrentLevelNumber();
        }
    }


    public void LoadLevels( int level) {
        currentLevel = Instantiate(levelsAvailable[level]) as GameObject;
        currentLevel.transform.position = new Vector3(0, 0, 0);
            //Instantiate(levelsAvailable[level], new Vector3(0, 0, 0), Quaternion.identity);
            menuAudio.StopMenuMusic();

    }
    
    public void LoadCurrentLevel(){

        currentLevel = Instantiate(levelsAvailable[levelNum]) as GameObject;
        currentLevel.transform.position = new Vector3(0, 0, 0);
    }

    public void DestroyLevel() {
        Destroy(currentLevel);
    }

    // jostain syystä pitää painaa kahdesti findcurrentlevelnumber, että vaihtuu. Pitää korjata
    public void FindCurrentLevelNumber(){
        for(int i = 0; i < levels.Length; i++){
            if( levels[i].GetComponent<MovingOnLevelsMap>().currentLevel == true ){
                levelNum = levels[i].GetComponent<MovingOnLevelsMap>().levelNumber;
            }
        }
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
