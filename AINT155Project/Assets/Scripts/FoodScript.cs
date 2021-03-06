﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour {

    public int Food = 0;
    public int ZombieParts = 0;
    int TutorialStage = 0;

    public Text TutorialText;
    public GameObject Tutorial;

    public delegate void UpdateZombiePartToUI(int amount);
    public static event UpdateZombiePartToUI OnSendParts;
    public delegate void UpdateFood(int amount);
    public static event UpdateFood OnSendFood;

    private void OnEnable()
    {
        Player.OnSendParts += UpdateZombiePart;
    }

    private void OnDisable()
    {
        Player.OnSendParts -= UpdateZombiePart;
    }
    private void UpdateZombiePart(int amount)
    {
        ZombieParts = ZombieParts + amount;
    
    }
    

    void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ZombieParts >5)
            {
                ZombieParts -= 6;
                OnSendParts(-6);
                Food++;
                OnSendFood(1);
                if (TutorialStage == 0)
                {
                    TutorialStage = 1;
                    TutorialText.text = "Press E to heal up to 15 health";
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if  (Food > 0)
            {
                GameObject.Find("Hero").transform.SendMessage("Heal", 15, SendMessageOptions.DontRequireReceiver);
                Food--;
                OnSendFood(-1);
                if (TutorialStage == 1)
                {
                    TutorialStage = 2;
                    Destroy(Tutorial);
                }
            }
        }
	}
}
