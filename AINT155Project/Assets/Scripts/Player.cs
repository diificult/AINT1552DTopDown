using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
<<<<<<< HEAD
=======



>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
    private Animator gunAnim;
    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
<<<<<<< HEAD
            GetComponent<Animator>().SetBool("isFiring", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
    }
    private void SendHealthData(int health)
=======
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }
    }

    public  void SendHealthData(int health)
>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
<<<<<<< HEAD
=======

>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
}
