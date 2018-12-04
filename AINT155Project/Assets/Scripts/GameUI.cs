using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public Slider HealthBar;
    public Slider ShieldBar;    
    public Text ScoreText;
    public Text KillsText;
    public Text RoundText;

    private int Kills = 0;
    private int PlayerScore = 0;
    
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        Player.OnUpdateShield += UpdateShieldBar;
        Player.OnSendScore += UpdateScore;
        AddScore.OnSendScore += UpdateScore;
        AddScore.OnSendKill += UpdateKill;
        SpawnerController.OnSendRound += UpdateRound;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        Player.OnUpdateShield -= UpdateShieldBar;
        Player.OnSendScore -= UpdateScore;
        AddScore.OnSendScore -= UpdateScore;
        AddScore.OnSendKill -= UpdateKill;
        SpawnerController.OnSendRound -= UpdateRound;
    }

    private void UpdateHealthBar(int health)
    {
        HealthBar.value = health;
    }

    private void UpdateShieldBar(int shield)
    {
        ShieldBar.value = shield;
    }

    private void UpdateScore(int score)
    {
        PlayerScore += score;
        ScoreText.text = PlayerScore.ToString();
    }

    private void UpdateRound(int round)
    {
        RoundText.text = "Round " + round;
    }

    private void UpdateKill()
    {
        Kills++;
        KillsText.text = Kills.ToString()  + " Kills";
    }

}
