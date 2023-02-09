using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//Added a namespace to contain 
public class Scoreboard : MonoBehaviour {
    public TextAsset ScoreHolder;
    
    [System.Serializable]
    public class ScoreBoardDataEntry
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class ScoreList
    { 
        public ScoreBoardDataEntry[] scores;
    }

    public ScoreList myScoreList = new ScoreList();
    void Start()
    {
        myScoreList = JsonUtility.FromJson<ScoreList>(ScoreHolder.text);
    }
}

