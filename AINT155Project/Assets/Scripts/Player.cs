using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public delegate void UpdateShield(int newShield);
    public static event UpdateShield OnUpdateShield;
    public delegate void SendScore(int score);
    public static event SendScore OnSendScore;

    private Animator gunAnim;
    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }
    }

    public  void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
      //      OnUpdateShield(shield);
        }
    }

    public void SendShieldData(int shield)
    {
        OnUpdateShield(shield);
    }

    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public int health = 100;
    public int shield = 100;
    public float resetTime = 3.5f;


    public float lastTookDamage;

    void FixedUpdate()
    {
        if ((Time.time - lastTookDamage > resetTime) && shield < 100)
        {
            
            shield++;
            OnUpdateShield(shield);
        }
    }

    public void TakeDamage(int damage)
    {
        lastTookDamage = Time.time;
        shield -= damage;
        if (shield < 0)
        {
            health += shield;
            shield -= shield;
        }
        OnUpdateHealth(health);
        OnUpdateShield(shield);

        if (health < 1)
        {
            onDie.Invoke();
        }
    }
    public void PickupCoin(int score)
    {
        OnSendScore(score);
    }
    }
