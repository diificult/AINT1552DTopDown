﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {


    public GameObject[] spawners;
    public int RoundOneZombies = 25;
    public int multiplier;
    public int ZombiesLeft;

    public int zombiesAlive = 0;
   
    public float delay = 5f;
    private bool wait;
    private int round = 1;
    private int Spawner;

    public Light mainLight;
    public Light torch;

  
    public delegate void SendRound(int round);
    public static event SendRound OnSendRound;

    public int GetRound()
    {
        return round;
    }

    void Awake()
    {
        StartRounds();
    }

    public void StartRounds()
    {
        ZombiesLeft = 3;
        zombiesAlive = 0;
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) + 25);
        StartCoroutine(SpawnTheZombies());
    }

    public void StartNextRound()
    {
        print("NextRound");
        StartCoroutine(StartNewRound());
    }

    IEnumerator StartNewRound()
    {
        
        if (round % 4 == 0)
        {
            mainLight.intensity = 0f;
            yield return new WaitForSeconds(0.1f);
            mainLight.intensity = 0.31f;
            yield return new WaitForSeconds(0.3f);
            mainLight.intensity = 0f;
            yield return new WaitForSeconds(0.2f);
            mainLight.intensity = 0.31f;
            yield return new WaitForSeconds(0.9f);
            mainLight.intensity = 0f;
            yield return new WaitForSeconds(1f);
            mainLight.intensity = 0.31f;
            yield return new WaitForSeconds(0.4f);
            mainLight.intensity = 0f;
            yield return new WaitForSeconds(1f);
            torch.enabled = true;
        }
        if (round == 3)
        {
            mainLight.intensity = 0.31f;
            torch.enabled = false;  
        }
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) +25);
        yield return new WaitForSeconds(15);
        StartCoroutine(SpawnTheZombies());
    }

    IEnumerator SpawnTheZombies()
    {
        Spawner = Random.Range(0, 4);
        spawners[Spawner].SendMessage("Spawn");
        zombiesAlive ++;
        ZombiesLeft --;
        float wait = 0.5f / round;
        yield return new WaitForSeconds(wait);

        if (ZombiesLeft > 0)
        {
            StartCoroutine(SpawnTheZombies());
        }
    }
    
    public void ZombieKilled()
    {
        zombiesAlive--;
        if (zombiesAlive <= 0 && ZombiesLeft <= 0)
        {
            round++;
            OnSendRound(round);
        
            
        }

        
    }


}
