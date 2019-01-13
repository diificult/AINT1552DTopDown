using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject[] Coins =  new GameObject[5];
    public float adjustmentAngle = 0;
    public int GetKills()
    {
        GameObject ZombieSpawner = GameObject.Find("Canvas");
        GameUI ui = ZombieSpawner.GetComponent<GameUI>();
        return ui.GetKills()++;
    }

    //public GameObject ZombieSpawner;


    public void Spawn()
    {
        int kills = GetKills();
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;
        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            Instantiate(Coins[0], transform.position, rotationInRadians);

        if (kills % 2 == 0) 
        {
            
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f),  0);
            Instantiate(Coins[0], SpawnLocation, rotationInRadians);
        }
        if (kills % 3 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Coins[1], SpawnLocation, rotationInRadians);
        }
        if (kills % 5 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Coins[2], SpawnLocation, rotationInRadians);
        }
        if (kills % 8 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Coins[3], SpawnLocation, rotationInRadians);
        }
        if (kills % 22 == 0)
        {
            Vector3 SpawnLocation = new Vector3(transform.position.x - Random.Range(-0.75f, 0.75f), transform.position.y + Random.Range(-0.75f, 0.75f), 0);
            Instantiate(Coins[4], SpawnLocation, rotationInRadians);
        }
        //Instantiate(prefabToSpawn, transform.position, rotationInRadians, spawnerParent);
    }
}
