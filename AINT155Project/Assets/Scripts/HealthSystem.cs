﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour {
    
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public int health = 85;

    public void TakeDamage(int damage)
    {

            health -= damage;
        onDamaged.Invoke(health);

        if (health < 1)
        {
            onDie.Invoke();
        }
    }

}
