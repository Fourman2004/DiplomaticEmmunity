using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
//Added a namespace to contain 
public class Scoreboard : MonoBehaviour {
    public TextAsset ScoreHolder;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    
    //Sets up a field for the indiidual parts of data
    [System.Serializable]
    public class ScoreBoardDataEntry
    {
        public string name;
        public int score;
    }
    // compiles the data into a list
    [System.Serializable]
    public class ScoreList
    { 
        public ScoreBoardDataEntry[] scores;
    }
    //reads the data from the JSON to the initialised list
    public ScoreList myScoreList = new ScoreList();
    void Start()
    {
        myScoreList = JsonUtility.FromJson<ScoreList>(ScoreHolder.text);
    }
    public ScoreBoardDataEntry newScore = new ScoreBoardDataEntry();
    public void addScore()
    {
        newScore.name = "You";
        newScore.score = 10;
        //figure out how to add the new score to the collection
        //myScoreList.add(newScore);
        string strOutput = JsonUtility.ToJson(myScoreList);
        File.WriteAllText(Application.dataPath + "/Resources/Scoreholder.text", strOutput);
    }

    public void displayScores() {
        //string tempString;
        foreach (var scores in myScoreList.scores)
        {
            score1.text =(scores.name);
        }
    }

}

