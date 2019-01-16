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
    public string GetPosition()
    {
        return Position;
    }
    public int GetScore()
    {
        return Score;
    }

    public void EndGame()
    {
        GameObject UIController = GameObject.Find("Canvas");
        GameUI ui = UIController.GetComponent<GameUI>();
        Score = ui.GetScore();
        if (Score >  PlayerPrefs.GetInt("First"))
        {
            PlayerPrefs.SetString("FifthName", PlayerPrefs.GetString("FourthName"));
            PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
            PlayerPrefs.SetString("FourthName", PlayerPrefs.GetString("ThirdName"));
            PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
            PlayerPrefs.SetString("ThirdName", PlayerPrefs.GetString("SecondName"));
            PlayerPrefs.SetInt("Third", PlayerPrefs.GetInt("Second"));
            PlayerPrefs.SetString("SecondName", PlayerPrefs.GetString("FirstName"));
            PlayerPrefs.SetInt("Second", PlayerPrefs.GetInt("First"));
            PlayerPrefs.SetInt("First", Score);
            PlayerPrefs.SetString("FirstName", "PLAYER");
            Position = "First";

        } else  if (Score > PlayerPrefs.GetInt("Second"))
        {
            PlayerPrefs.SetString("FifthName", PlayerPrefs.GetString("FourthName"));
            PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
            PlayerPrefs.SetString("FourthName", PlayerPrefs.GetString("ThirdName"));
            PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
            PlayerPrefs.SetString("ThirdName", PlayerPrefs.GetString("SecondName"));
            PlayerPrefs.SetInt("Third", PlayerPrefs.GetInt("Second"));
            Position = "Second";
            PlayerPrefs.SetInt("Second", Score);
            PlayerPrefs.SetString("SecondName", "PLAYER");
        }
        else if (Score > PlayerPrefs.GetInt("Third"))
        {
            PlayerPrefs.SetString("FifthName", PlayerPrefs.GetString("FourthName"));
            PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
            PlayerPrefs.SetString("FourthName", PlayerPrefs.GetString("ThirdName"));
            PlayerPrefs.SetInt("Fourth", PlayerPrefs.GetInt("Third"));
            PlayerPrefs.SetInt("Third", Score);
            PlayerPrefs.SetString("ThirdName", "PLAYER");
            Position = "Third";
        }
        else if (Score > PlayerPrefs.GetInt("Fourth"))
        {
            PlayerPrefs.SetString("FifthName", PlayerPrefs.GetString("FourthName"));
            PlayerPrefs.SetInt("Fifth", PlayerPrefs.GetInt("Fourth"));
            PlayerPrefs.SetInt("Fourth", Score);
            PlayerPrefs.SetString("FourthName", "PLAYER");
            Position = "Fourth";
        }
        else if (Score > PlayerPrefs.GetInt("Fifth"))
        {
            PlayerPrefs.SetInt("Fifth", Score);
            PlayerPrefs.SetString("FifthName", "PLAYER");
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
            PlayerPrefs.SetString(Position + "Name", Name.text);
        }
        SceneManager.LoadScene("_MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
