using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDie : MonoBehaviour {

    public float dieTime = 0;

	public void Die()
    {
        Destroy(gameObject, dieTime);
    }
}
