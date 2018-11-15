using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    public int StartStamina = 150;
   // public int RestartStamina = 25;
    private int CurrentStamina;
    void Start()
    {
        CurrentStamina = StartStamina;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0)
        {
            speed = 10f;
            CurrentStamina--;
        } else if (CurrentStamina < 25) { }
        else
        {
            speed = 7f;
            if (CurrentStamina < StartStamina) CurrentStamina++;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y).normalized;

        rigidbody2D.velocity = velocity * speed;

        rigidbody2D.angularVelocity = 0.0f;
    }
   

}
