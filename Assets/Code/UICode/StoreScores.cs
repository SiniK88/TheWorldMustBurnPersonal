using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScores : MonoBehaviour
{
    public Text L1pronceText;
    public Text L1SilverText;
    public Text L1GoldText;
    public Text L2pronceText;
    public Text L2SilverText;
    public Text L2GoldText;
    public Text L3pronceText;
    public Text L3SilverText;
    public Text L3GoldText;

    public float l1HighScorePronce = 0;
    public float l1HighScoreSilver = 0;
    public float l1HighScoreGold = 0;
    public float l2HighScorePronce = 0;
    public float l2HighScoreSilver = 0;
    public float l2HighScoreGold = 0;
    public float l3HighScorePronce = 0;
    public float l3HighScoreSilver = 0;
    public float l3HighScoreGold = 0;

    public float l1SecondsPronce;
    public float l1SecondsSilver;
    public float l1SecondsGold;
    public float l2SecondsPronce;
    public float l2SecondsSilver;
    public float l2SecondsGold;
    public float l3SecondsPronce;
    public float l3SecondsSilver;
    public float l3SecondsGold;

    public int tileamountlv1 = 1;
    public int tileamountlv2 = 1;
    public int tileamountlv3 = 1;


    void Update()
    {
        L1pronceText.text = Mathf.RoundToInt((l1HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l1SecondsPronce / 60) + " min " + Mathf.RoundToInt(l1SecondsPronce % 60) + " s ";
        L1SilverText.text = Mathf.RoundToInt((l1HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l1SecondsSilver / 60) + " min " + Mathf.RoundToInt(l1SecondsSilver % 60) + " s ";
        L1GoldText.text = Mathf.RoundToInt((l1HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l1SecondsGold / 60) + " min " + Mathf.RoundToInt(l1SecondsGold % 60) + " s ";

        L2pronceText.text = Mathf.RoundToInt((l2HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l2SecondsPronce / 60) + " min " + Mathf.RoundToInt(l2SecondsPronce % 60) + " s ";
        L2SilverText.text = Mathf.RoundToInt((l2HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l2SecondsSilver / 60) + " min " + Mathf.RoundToInt(l2SecondsSilver % 60) + " s ";
        L2GoldText.text = Mathf.RoundToInt((l2HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l2SecondsGold / 60) + " min " + Mathf.RoundToInt(l2SecondsGold % 60) + " s ";


        L3pronceText.text = Mathf.RoundToInt((l3HighScorePronce) * 100) + " % " + Mathf.RoundToInt(l3SecondsPronce / 60) + " min " + Mathf.RoundToInt(l3SecondsPronce % 60) + " s ";
        L3SilverText.text = Mathf.RoundToInt((l3HighScoreSilver) * 100) + " % " + Mathf.RoundToInt(l3SecondsSilver / 60) + " min " + Mathf.RoundToInt(l3SecondsSilver % 60) + " s ";
        L3GoldText.text = Mathf.RoundToInt((l3HighScoreGold) * 100) + " % " + Mathf.RoundToInt(l3SecondsGold / 60) + " min " + Mathf.RoundToInt(l3SecondsGold % 60) + " s ";
    }
}
