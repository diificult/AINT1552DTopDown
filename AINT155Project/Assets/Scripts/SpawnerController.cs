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
   
    public float delay = 5f;
    public float roundResetDelay = 30f;
    private bool wait;
    private int round = 1;
    private int Spawner;

    public Spawner SpawnerScript;

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
        StartCoroutine(StartRound());
    }


    IEnumerator StartRound()
    {
        Spawner = Random.Range(0, 4);
        spawners[Spawner].SendMessage("Spawn");
        zombiesAlive++;

        yield return new WaitForSeconds(1);
        print("round 1 complete");

        ZombiesLeft--;

        if (ZombiesLeft > 0)
        {
            StartCoroutine(StartRound());
        }
    }

    IEnumerator Round()
    {
    //    print("RAN Round");
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) + 25);
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
        // total alive --
        zombiesAlive--;

        if (zombiesAlive <= 0)
        {
            StartCoroutine(StartRound());
            print("level won");
        }

        
    }


        /*
        while (ZombiesLeft > 0)
        {
            int ZombiesToSpawn = ZombiesLeft;
            if (ZombiesLeft > 12)
            {

                ZombiesToSpawn = Random.Range(6, ZombiesLeft / 2);
            }

            int Spawner = Random.Range(0, 4);
            while (ZombiesToSpawn > 0) {
                if (!wait)
                {
               //     spawners[Spawner].transform.SendMessage("Spawn");
                    wait = true;
                    Invoke("DelayedSpawn", delay);
                    ZombiesLeft--;
                    ZombiesToSpawn--;
                }
            }
        }
        */
    

    


}
