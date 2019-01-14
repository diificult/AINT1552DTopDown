using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    // Use this for initialization
    public void StartGame()
    {
        SceneManager.LoadScene("_Level1");
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("_GameOver");
    }

    public void Return()
    {
        SceneManager.LoadScene("_MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
