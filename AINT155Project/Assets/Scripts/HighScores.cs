using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text[] HighScoresText  = new Text[5];
    public Text PositionText;
    public Text ScoreText;
    public GameObject GameManagerObject;


    void Start () {
        HighScoresText[0].text = PlayerPrefs.GetString("FirstName") +  " - " + PlayerPrefs.GetInt("First");
        HighScoresText[1].text = PlayerPrefs.GetString("SecondName") + " - " + PlayerPrefs.GetInt("Second");
        HighScoresText[2].text = PlayerPrefs.GetString("ThirdName") + " - " + PlayerPrefs.GetInt("Third");
        HighScoresText[3].text = PlayerPrefs.GetString("FourthName") + " - " + PlayerPrefs.GetInt("Fourth");
        HighScoresText[4].text = PlayerPrefs.GetString("FifthName") + " - " + PlayerPrefs.GetInt("Fifth");
        GameManager ui = GameManagerObject.GetComponent<GameManager>();
        
        string Position = ui.GetPosition();
        if (Position == "")
        {
            PositionText.text = "You didn't get onto the leaderboard!";
        }  else
        {
            PositionText.text = "Your position: " + Position;
        }
        int Score = ui.GetScore();
        ScoreText.text = Score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
