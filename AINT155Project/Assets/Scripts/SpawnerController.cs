using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {


    public GameObject[] spawners;
    public int RoundOneZombies = 25;
    public int multiplier;
    public int ZombiesLeft;
    public int ZombiesToSpawn;
    public int zombiesAlive = 0;
    public int kills=0;
   
    public float delay = 5f;
    public float roundResetDelay = 5f;
    private bool wait;
    private int round = 1;
    private int Spawner;

    public Light mainLight;
    public Light torch;

    public delegate void SendRound(int round);
    public static event SendRound OnSendRound;

    public int GetKills()
    {
        return kills;
    }

    void Awake()
    {
        StartRounds();
    }

    public void StartRounds()
    {
        //       print("RANSR");
        //StartCoroutine("Round");
        ZombiesLeft = 3;
        zombiesAlive = 0;
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) + 25);
        StartCoroutine(SpawnTheZombies());
    }

    IEnumerator StartNewRound()
    {
        round++;
        OnSendRound(round);
        if (round == 2)
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
            mainLight.intensity = 0.55f;
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
        zombiesAlive++;

        yield return new WaitForSeconds(0.5f);

        ZombiesLeft--;

        if (ZombiesLeft > 0)
        {
            StartCoroutine(SpawnTheZombies());
        }
    }

    IEnumerator Round()
    {
    //    print("RAN Round");
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) + 2);
        StartCoroutine("ZombiesCalcuation");
        round++;    
        yield return new WaitForSecondsRealtime(roundResetDelay);
       // StartCoroutine("Round");
    }

    IEnumerator ZombiesCalcuation()
    {
        print("RAN ZombieCalulation");

       ZombiesToSpawn = ZombiesLeft;
        if (ZombiesLeft > 12)
        {
            ZombiesToSpawn = Random.Range(6, ZombiesLeft / 2);
        }
        Spawner = Random.Range(0, 4);
        StartCoroutine("SpawnZombies");
        
        if (ZombiesLeft > 0)
        {
            yield return new WaitForSecondsRealtime(delay);
            StartCoroutine("ZombiesCalcuation");
            
        }
    }
    
    IEnumerator SpawnZombies()
    {
        //print("Ran SZ1");
        spawners[Spawner].SendMessage("Spawn");
     //   print("Ran SZ2");
        ZombiesLeft--;
        ZombiesToSpawn--;
        yield return new WaitForSecondsRealtime(delay);
        if (ZombiesToSpawn > 0) StartCoroutine("SpawnZombies");
    }

    public void ZombieKilled()
    {
        zombiesAlive--;
        //kills++;

        if (zombiesAlive <= 0 && ZombiesLeft <= 0)
        {
            print("level won");
            StartCoroutine(StartNewRound());
            
        }

        
    }


}
