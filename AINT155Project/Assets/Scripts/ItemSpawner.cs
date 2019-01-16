using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] Items =  new GameObject[6];
    public GameObject[] Powerups = new GameObject[2];
    public float adjustmentAngle = 0;
    
    public int GetKills()
    {
        GameObject UIController = GameObject.Find("Canvas");
        GameUI ui = UIController.GetComponent<GameUI>();
        return (ui.GetKills()+1);
    }

    public int GetRound()
    {
        GameObject ZombieSpawner = GameObject.Find("SpawnerController");
        SpawnerController sc = ZombieSpawner.GetComponent<SpawnerController>();
        return (sc.GetRound());
    }

    //public GameObject ZombieSpawner;


    public void Spawn()
    {
        int kills = GetKills();
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;
        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            Instantiate(Items[0], transform.position, rotationInRadians);

        if (kills % 2 == 0) 
        {
            
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f),  0);
            Instantiate(Items[0], SpawnLocation, rotationInRadians);
        }
        if (kills % 3 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Items[1], SpawnLocation, rotationInRadians);
        }
        if (kills % 5 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Items[2], SpawnLocation, rotationInRadians);
        }
        if (kills % 8 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Items[3], SpawnLocation, rotationInRadians);
        }
        if (kills % 22 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Items[4], SpawnLocation, rotationInRadians);
        }
        int x = GetRound();
        if (0 < x && x <= 40) 
        {
            int MaxValue = (-x / 2) + 60;
            int chance = Random.Range(0, 100);
            if (chance < MaxValue)
            {
                Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
                Instantiate(Items[5], SpawnLocation, rotationInRadians);
            }
        }
        if (40 < x && x <= 120)
        {
            int MaxValue = (-x / 8) + 45;
            int chance = Random.Range(0, 100);
            if (chance < MaxValue)
            {
                Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
                Instantiate(Items[5], SpawnLocation, rotationInRadians);
            }
        }
        if (120 < x )
        {
            int MaxValue = 30;
            int chance = Random.Range(0, 100);
            if (chance < MaxValue)
            {
                Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
                Instantiate(Items[5], SpawnLocation, rotationInRadians);
            }
        }
        int RandomNumber = Random.Range(1, 100);
        if (RandomNumber == 45)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Powerups[0], SpawnLocation, rotationInRadians);
        } if (RandomNumber ==  67)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Powerups[1], SpawnLocation, rotationInRadians);
        }

        //Instantiate(prefabToSpawn, transform.position, rotationInRadians, spawnerParent);
    }
}
