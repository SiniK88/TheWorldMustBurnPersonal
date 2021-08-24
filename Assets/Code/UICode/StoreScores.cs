using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScores : MonoBehaviour
{
    public int levelAmount = 5;



    public Text bronceText;
    public Text silverText;
    public Text goldText;
    public Text LevelTitle;


    public int tileamountlv1 = 1;
    public int tileamountlv2 = 1;
    public int tileamountlv3 = 1;
    public int tileamountlv4 = 1;
    public int tileamountlv5 = 1;

    // should make highscores etc. as array/list. Just as levels are


    public float[] bronceHighScores = new float[5];
    public float[] silverHighScores = new float[5];
    public float[] goldHighScores = new float[5];

    public float[] bronceHighSeconds = new float[5];
    public float[] silverHighSeconds = new float[5];
    public float[] goldHighSeconds = new float[5];
    public int[] tileAmounts = new int[5];

    public GameObject[] levels;
    public GameObject[] locks;

    public GameObject player;

    private void Start() {
        levels = GameObject.FindGameObjectsWithTag("Level");
        locks = GameObject.FindGameObjectsWithTag("Locks");
    }

    void Update() {

        UpdateScores();
        /*L1pronceText.text = Mathf.RoundToInt((l1HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l1SecondsPronce / 60) + " min " + Mathf.RoundToInt(l1SecondsPronce % 60) + " s ";
        L1SilverText.text = Mathf.RoundToInt((l1HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l1SecondsSilver / 60) + " min " + Mathf.RoundToInt(l1SecondsSilver % 60) + " s ";
        L1GoldText.text = Mathf.RoundToInt((l1HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l1SecondsGold / 60) + " min " + Mathf.RoundToInt(l1SecondsGold % 60) + " s ";

        L2pronceText.text = Mathf.RoundToInt((l2HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l2SecondsPronce / 60) + " min " + Mathf.RoundToInt(l2SecondsPronce % 60) + " s ";
        L2SilverText.text = Mathf.RoundToInt((l2HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l2SecondsSilver / 60) + " min " + Mathf.RoundToInt(l2SecondsSilver % 60) + " s ";
        L2GoldText.text = Mathf.RoundToInt((l2HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l2SecondsGold / 60) + " min " + Mathf.RoundToInt(l2SecondsGold % 60) + " s ";


        L3pronceText.text = Mathf.RoundToInt((l3HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l3SecondsPronce / 60) + " min " + Mathf.RoundToInt(l3SecondsPronce % 60) + " s ";
        L3SilverText.text = Mathf.RoundToInt((l3HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l3SecondsSilver / 60) + " min " + Mathf.RoundToInt(l3SecondsSilver % 60) + " s ";
        L3GoldText.text = Mathf.RoundToInt((l3HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l3SecondsGold / 60) + " min " + Mathf.RoundToInt(l3SecondsGold % 60) + " s ";
        */

        // make these better later. Doesn't need to run on every frame, just occasionally. For example, run some function when level ends.

        for (int j = 0; j < levels.Length; j++) {
            if (bronceHighScores[j] >= 0.5 || silverHighScores[j] >= 0.5 || goldHighScores[j] >= 0.5) {
                levels[j + 1].GetComponent<MovingOnLevelsMap>().locked = false;
                locks[j + 1].SetActive(false);
            }
        }

        //if (bronceHighScores[0] >= 0.5 || silverHighScores[0] >= 0.5 || goldHighScores[0] >= 0.5) {
        //    levels[1].GetComponent<MovingOnLevelsMap>().locked = false;
        //    locks[1].SetActive(false);
        //}

        //if (bronceHighScores[1] >= 0.5 || silverHighScores[1] >= 0.5 || goldHighScores[1] >= 0.5) {
        //    levels[2].GetComponent<MovingOnLevelsMap>().locked = false;
        //    locks[2].SetActive(false);
        //}
    }

    public void UpdateScores() {
        for(int i = 0; i < levels.Length; i++) {
            if (player.transform.position == levels[i].transform.position) {
                bronceText.text = Mathf.RoundToInt((bronceHighScores[i]) * 100) + " % " + Mathf.RoundToInt(bronceHighSeconds[i] / 60) + " min " + Mathf.RoundToInt(bronceHighSeconds[i] % 60) + " s ";
                silverText.text = Mathf.RoundToInt((silverHighScores[i]) * 100) + " % " + Mathf.RoundToInt(silverHighSeconds[i] / 60) + " min " + Mathf.RoundToInt(silverHighSeconds[i] % 60) + " s ";
                goldText.text = Mathf.RoundToInt((goldHighScores[i]) * 100) + " % " + Mathf.RoundToInt(goldHighSeconds[i] / 60) + " min " + Mathf.RoundToInt(goldHighSeconds[i] % 60) + " s ";
                LevelTitle.text = "Highscores level  " + (i + 1); 

            }
        }
    }

}
