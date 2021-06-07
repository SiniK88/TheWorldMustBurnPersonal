using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int levelNumber = 1;
    public float scoreValue = 0;
    Text score;
    public GameObject timer;
    public FireManager fm;
    GameTimer gameTimer;
    StoreScores storeScores;
    [SerializeField] int burnableTilesCount;
    public float runningScore;
    public float perScore;

    public GameObject bronce, silver, gold;
    void Start()
    {
        burnableTilesCount = fm.GetComponent<FireManager>().GetTileAmountSprite();
        print(burnableTilesCount);
        score = GetComponent<Text>();
        gameTimer = FindObjectOfType<GameTimer>();
        storeScores = FindObjectOfType<StoreScores>();
        scoreValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        runningScore = Mathf.RoundToInt((scoreValue / burnableTilesCount) * 100);
        score.text = "Score: " + Mathf.RoundToInt((scoreValue / burnableTilesCount)*100) + " %";

        if(runningScore < 50) {
            silver.SetActive(false);
            bronce.SetActive(false);
            gold.SetActive(false);
        }else if(runningScore >= 50 && runningScore < 75) {
            bronce.SetActive(true);
        } else if (runningScore >= 75 && runningScore < 100) {
            silver.SetActive(true);
            bronce.SetActive(false);
        } else if (runningScore >= 100) {
            silver.SetActive(false);
            bronce.SetActive(false);
            gold.SetActive(true);
        } 

    }

    public void RegisterNewScore(int levelNum) {
        if (levelNum == 1) {
            perScore = scoreValue / burnableTilesCount;
            if(perScore >= 0.50 && perScore < 0.75) {
                if (perScore > storeScores.l1HighScorePronce) {
                    storeScores.l1HighScorePronce = perScore;
                    storeScores.l1SecondsPronce = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 0.75 && perScore < 1) {
                if (perScore > storeScores.l1HighScoreSilver) {
                    storeScores.l1HighScoreSilver = perScore;
                    storeScores.l1SecondsSilver = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 1) {
                if (perScore > storeScores.l1HighScoreGold) {
                    storeScores.l1HighScoreGold = perScore;
                    storeScores.l1SecondsGold = gameTimer.gameTime - gameTimer.timer;
                }
            }
        }


        if (levelNum == 2) {
             perScore = scoreValue / burnableTilesCount;
            if (perScore >= 0.50 && perScore < 0.75) {
                if (perScore > storeScores.l2HighScorePronce) {
                    storeScores.l2HighScorePronce = perScore;
                    storeScores.l2SecondsPronce = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 0.75 && perScore < 1) {
                if (perScore > storeScores.l2HighScoreSilver) {
                    storeScores.l2HighScoreSilver = perScore;
                    storeScores.l2SecondsSilver = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 1) {
                if (perScore > storeScores.l2HighScoreGold) {
                    storeScores.l2HighScoreGold = perScore;
                    storeScores.l2SecondsGold = gameTimer.gameTime - gameTimer.timer;
                }
            }

        }

        if (levelNum == 3) {
            perScore = scoreValue / burnableTilesCount;
            if (perScore >= 0.50 && perScore < 0.75) {
                if (perScore > storeScores.l3HighScorePronce) {
                    storeScores.l3HighScorePronce = perScore;
                    storeScores.l3SecondsPronce = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 0.75 && perScore < 1) {
                if (perScore > storeScores.l3HighScoreSilver) {
                    storeScores.l3HighScoreSilver = perScore;
                    storeScores.l3SecondsSilver = gameTimer.gameTime - gameTimer.timer;
                }
            } 
            if (perScore >= 1) {
                if (perScore > storeScores.l3HighScoreGold) {
                    storeScores.l3HighScoreGold = perScore;
                    storeScores.l3SecondsGold = gameTimer.gameTime - gameTimer.timer;
                }
            }

        }
    }




}// class
