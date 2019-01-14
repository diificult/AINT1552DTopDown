using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    static int Score;
    static string Position = "";

    public InputField Name; 

    // Use this for initialization
    public void StartGame()
    {
        SceneManager.LoadScene("_Level1");
    }

    public void EndGame()
    {
        GameObject UIController = GameObject.Find("Canvas");
        GameUI ui = UIController.GetComponent<GameUI>();
        Score = ui.GetScore();
        if (Score >  PlayerPrefs.GetInt("First"))
        {
            PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
            PlayerPrefs.SetInt("First", Score);
            Position = "First";

        } else  if (Score > PlayerPrefs.GetInt("Second"))
        {
            Position = "Second";
        }
        else if (Score > PlayerPrefs.GetInt("Third"))
        {
            Position = "Third";
        }
        else if (Score > PlayerPrefs.GetInt("Fourth"))
        {
            Position = "Fourth";
        }
        else if (Score > PlayerPrefs.GetInt("Fifth"))
        {
            Position = "Fifth";
        }
        if (Position != "")
        {
            PlayerPrefs.SetInt(Position, Score);
        }
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("_GameOver");
    }


    public void Return()
    {
        if (Position != "")
        {
            PlayerPrefs.SetInt(Position + "Name", System.Convert.ToInt32(Name.text));
        }
        SceneManager.LoadScene("_MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
