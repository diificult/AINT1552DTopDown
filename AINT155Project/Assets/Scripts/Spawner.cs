using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float adjustmentAngle = 0;

    public Transform spawnerParent;

    public void Spawn(int count)
    {
        
        StartCoroutine(SpawnLoop(count));
        
    }

    IEnumerator SpawnLoop(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 rotationInDegrees = transform.eulerAngles;
            rotationInDegrees.z += adjustmentAngle;
            Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            Instantiate(prefabToSpawn, transform.position, rotationInRadians, spawnerParent);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
