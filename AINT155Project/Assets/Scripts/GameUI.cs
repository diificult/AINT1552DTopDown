using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public Slider HealthBar;
    public Text ScoreText;
    public Text KillsText;

    private int Kills = 0;
    private int PlayerScore = 0;
    
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        AddScore.OnSendKill += UpdateKill;

    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        AddScore.OnSendKill -= UpdateKill;
    }

    private void UpdateHealthBar(int health)
    {
        HealthBar.value = health;
    }

    private void UpdateScore(int score)
    {
        PlayerScore += score;
        ScoreText.text = PlayerScore.ToString();
    }

    private void UpdateKill()
    {
        Kills++;
        KillsText.text = Kills.ToString()  + " Kills";
    }

}
