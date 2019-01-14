using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

    public int Food = 0;
    public int ZombieParts = 0;

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
            if (ZombieParts >4)
            {
                ZombieParts -= 5;
                OnSendParts(-5);
                Food++;
                OnSendFood(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if  (Food > 0)
            {
                GameObject.Find("Hero").transform.SendMessage("Heal", 15, SendMessageOptions.DontRequireReceiver);
                Food--;
                OnSendFood(-1);
            }
        }
	}
}
