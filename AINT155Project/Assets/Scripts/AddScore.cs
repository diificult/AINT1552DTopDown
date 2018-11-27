
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int score);
    public static event SendScore OnSendScore;
    public delegate void SendKill();
    public static event SendKill OnSendKill;

    public int KillScore = 10;
    public int DamageScore = 2;
    public void OnDestroy()
    {
        if (OnSendScore != null)
        {
            OnSendScore(KillScore);
            OnSendKill();
        }

        transform.parent.SendMessage("ZombieKilled");

    }

    public void OnDamaged()
    {
        if  (OnSendScore != null)
        {
            OnSendScore(DamageScore);
        }
    }

}


