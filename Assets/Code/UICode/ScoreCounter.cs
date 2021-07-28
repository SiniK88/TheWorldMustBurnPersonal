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

    public void RegisterScore() {
        for (int i = 0; i < 3; i++) {
            if (levelNumber == i + 1) {
                if (perScore >= 0.5 && perScore < 0.75) {
                    if (perScore > storeScores.bronceHighScores[i]) {
                        storeScores.bronceHighScores[i] = perScore;
                        storeScores.bronceHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                    }
                }
                if (perScore >= 0.75 && perScore < 1) {
                    if (perScore > storeScores.silverHighScores[i]) {
                        storeScores.silverHighScores[i] = perScore;
                        storeScores.silverHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                    }
                }
                if (perScore >= 1) {
                    if (perScore > storeScores.goldHighScores[i]) {
                        storeScores.goldHighScores[i] = perScore;
                        storeScores.goldHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                    }
                }
            }
        }
    }

    public void RegisterNewScore(int levelNum) {
        for(int i = 0; i < storeScores.levels.Length; i++) {
            perScore = scoreValue / burnableTilesCount;
            if (perScore >= 0.50 && perScore < 0.75) {
                if (perScore > storeScores.bronceHighScores[i]) {
                    storeScores.bronceHighScores[i] = perScore;
                    storeScores.bronceHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                }
            }
            if (perScore >= 0.75 && perScore < 1) {
                if (perScore > storeScores.silverHighScores[i]) {
                    storeScores.silverHighScores[i] = perScore;
                    storeScores.silverHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                }
            }
            if (perScore >= 1) {
                if (perScore > storeScores.goldHighScores[i]) {
                    storeScores.goldHighScores[i] = perScore;
                    storeScores.goldHighSeconds[i] = gameTimer.gameTime - gameTimer.timer;
                }
            }
        }


    }




}// class
