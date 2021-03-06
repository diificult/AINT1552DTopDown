﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public float fireTime = 0.3f;
    public Light bulletFire1;

    private bool isFiring = false;

    public Image DamageIcon;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
        bulletFire1.enabled = true;
        GetComponent<AudioSource>().Play();
        Invoke("TurnOffLight", fireTime);
        Invoke("SetFiring", fireTime);
    }

    public void ShowWeaponPowerup()
    {
        DamageIcon.GetComponent<Image>().enabled = true;
    }

    public void HideWeaponPowerup()
    {
        DamageIcon.GetComponent<Image>().enabled = false ;
    }

    private void TurnOffLight()
    {
        bulletFire1.enabled = false;

    }
    private void Update()
    {
       if (Input.GetAxis("Fire1") == 1)
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
