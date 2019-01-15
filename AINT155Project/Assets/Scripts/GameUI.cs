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
    public Text RoundCompleteText;
    public Text PartsText;
    public Text FoodText;
    public SpawnerController SC;

    public int ZombieParts = 0;
    public int Kills = 0;
    private int PlayerScore = 0;
    public int Food=0;


    private bool EndRound = false;
    
    public int GetKills()
    {
        return Kills;
    }
    public int GetScore()
    {
        return PlayerScore;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (EndRound)
            {
                StartCoroutine(DisableText());
                EndRound = false;
                SC.StartNextRound();
            }
        }
    }

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        Player.OnUpdateShield += UpdateShieldBar;
        Player.OnSendScore += UpdateScore;
        AddScore.OnSendScore += UpdateScore;
        AddScore.OnSendKill += UpdateKill;
        SpawnerController.OnSendRound += UpdateRound;
        Player.OnSendParts += UpdateZombiePart;
        FoodScript.OnSendParts += UpdateZombiePart;
        FoodScript.OnSendFood += UpdateFood;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        Player.OnUpdateShield -= UpdateShieldBar;
        Player.OnSendScore -= UpdateScore;
        AddScore.OnSendScore -= UpdateScore;
        AddScore.OnSendKill -= UpdateKill;
        SpawnerController.OnSendRound -= UpdateRound;
        Player.OnSendParts -= UpdateZombiePart;
        FoodScript.OnSendParts -= UpdateZombiePart;
        FoodScript.OnSendFood -= UpdateFood;
    }

    private  void UpdateFood(int amount)
    {
        Food += amount;
        FoodText.text = Food.ToString();
    }

    private void UpdateZombiePart(int amount)
    {
        ZombieParts = ZombieParts + amount;
        PartsText.text = ZombieParts.ToString();
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
        StartCoroutine(PostRound(round));
     
    }
    IEnumerator  PostRound(int round)
        {
        string DisplayWinText = "Round " + (round-1) + " Defeated!";
        StartCoroutine(UpdateRoundText(DisplayWinText));
        RoundCompleteText.enabled = true;
        yield return new WaitForSeconds(5f);
        StartCoroutine(DisableText());
        yield return new WaitForSeconds(1f);
        StartCoroutine(UpdateRoundText("Press R to continue to the next round"));
        yield return new WaitForSeconds(1f);
        EndRound = true;
    }
    IEnumerator UpdateRoundText(string text) {
        char[] TextCharArray = text.ToCharArray();
        string DisplayedText = "";
        foreach (char character in TextCharArray)
        {
            DisplayedText += character;
            RoundCompleteText.text = DisplayedText;
            yield return new WaitForSeconds(0.03f);
        }
    }
    IEnumerator DisableText()
    {
        
        string DisplayedText = RoundCompleteText.text;
        for (int i = DisplayedText.Length -1  ; i >= 0; i--)
        {
            DisplayedText = DisplayedText.Remove(i);
            RoundCompleteText.text = DisplayedText;
            yield return new WaitForSeconds(0.03f);
        }
    }

    


    private void UpdateKill()
    {
        Kills++;
        KillsText.text = Kills.ToString()  + " Kills";
    }

}
