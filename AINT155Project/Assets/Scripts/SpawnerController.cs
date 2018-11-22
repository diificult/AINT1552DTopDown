using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {


    public GameObject[] spawners;
    public int RoundOneZombies = 25;
    public int multiplier;
    public int ZombiesLeft;
    public int ZombiesToSpawn;
   
    public float delay = 0.25f;
    public float roundResetDelay = 5f;
    private bool wait;
    private int round = 1;
    private int Spawner;

    public Spawner SpawnerScript;

    void Start()
    {
        StartCoroutine("Round");
    }

    IEnumerable Round()
    {
        ZombiesLeft = Mathf.RoundToInt(5 * Mathf.Pow(round, 1.6f) + 25);
        StartCoroutine("ZombiesCalcuation");
        round++;
        yield return new WaitForSeconds(roundResetDelay);
        StartCoroutine("Round");
    }

    IEnumerable ZombiesCalcuation()
    {
        ZombiesToSpawn = ZombiesLeft;
        if (ZombiesLeft > 12)
        {
            ZombiesToSpawn = Random.Range(6, ZombiesLeft / 2);
        }
        Spawner = Random.Range(0, 4);
        StartCoroutine("SpawnZombies");
        yield return new WaitForSeconds(0f);
        if (ZombiesLeft > 0) StartCoroutine("ZombiesCalcuation");
    }

    IEnumerable SpawnZombies()
    {
        spawners[Spawner].SendMessage("Spawn");
        ZombiesLeft--;
        ZombiesToSpawn--;
        yield return new WaitForSeconds(delay);
        if (ZombiesToSpawn > 0) StartCoroutine("SpawnZombies");
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
