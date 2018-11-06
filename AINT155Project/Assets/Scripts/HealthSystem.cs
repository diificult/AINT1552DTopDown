using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour {
    
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public int health = 10;
    public int maxHealable = 10;
    public int healthpacks = 3;
    public int healthHeals = 3;



    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    public  void UseHealthPack()
    {
        health += healthHeals;
        while (health > maxHealable)
        {
            health--;
        }
    }
}
