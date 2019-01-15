using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text[] HighScoresText  = new Text[5];


	void Start () {
        HighScoresText[0].text = PlayerPrefs.GetString("FirstName") +  " - " + PlayerPrefs.GetInt("First");
        HighScoresText[1].text = PlayerPrefs.GetString("SecondName") + " - " + PlayerPrefs.GetInt("Second");
        HighScoresText[2].text = PlayerPrefs.GetString("ThirdName") + " - " + PlayerPrefs.GetInt("Third");
        HighScoresText[3].text = PlayerPrefs.GetString("FourthName") + " - " + PlayerPrefs.GetInt("Fourth");
        HighScoresText[4].text = PlayerPrefs.GetString("FifthName") + " - " + PlayerPrefs.GetInt("Fifth");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
