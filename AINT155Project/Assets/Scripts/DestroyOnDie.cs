﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDie : MonoBehaviour {

	// Use this for initialization
	public void Die()
    {
        Destroy(gameObject);
    }
}
