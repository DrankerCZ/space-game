using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text score;
    public Text highscore;
    public static int scoreValue = 0;
    public static int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        SaveHighscore High = JsonUtility.FromJson<SaveHighscore>(File.ReadAllText(Application.dataPath + "/highscore.json"));
        highScore = int.Parse(High.HS);
    }

    // Update is called once per frame
    void Update()
    {
        if (score.text != null) score.text = "Score: " + scoreValue;
    }

    public void OnEnd()
    {
        if (scoreValue > highScore)
        {
            SaveHighscore newHigh = new SaveHighscore();
            highScore = scoreValue;
            if (highscore.text != null) highscore.text = "High score: " + highScore;
            newHigh.HS = highScore.ToString();

            string json = JsonUtility.ToJson(newHigh);
            File.WriteAllText(Application.dataPath + "/highscore.json", json);
        }
    }

    [Serializable]
    public class SaveHighscore
    {
        public string HS;
    }
}
