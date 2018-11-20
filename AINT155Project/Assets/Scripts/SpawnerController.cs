using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {


    public GameObject[] spawners;
    public int RoundOneZombies = 25;
    public int multiplier;
    public int ZombiesLeft;
    public float delay;
    private bool wait;

     void Start()
    {
        ZombiesLeft = RoundOneZombies;
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
    }

    void DelayedSpawn(int index)
    {
        wait = false;
    }



}
