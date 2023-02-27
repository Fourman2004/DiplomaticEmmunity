using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ScoreboardV2 : MonoBehaviour
{
    private ScoreList Scores;
    public Text ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        // loading data from text file
        string ScoreDataString = Resources.Load("ScoreHolder").ToString();
        Scores = JsonConvert.DeserializeObject<ScoreList>(ScoreDataString);
    }

    private void DisplayScores() {
        Text SpecificTowerButton = Instantiate(ScoreDisplay
    }

    public class ScoreBoardDataEntry
    {
        public string name { get; set; }
        public int score { get; set; }
    }
    public class ScoreList
    {
        public List<ScoreBoardDataEntry> scores { get ; set ;}
    }
}
