using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 7.0f;
    Rigidbody2D rigidbody2D;
<<<<<<< HEAD
    public int StartStamina = 150;
   // public int RestartStamina = 25;
    private int CurrentStamina;
=======
    public int StartStamina = 50;
    public int CurrentStamina;
    public float CooldownTime = 0.25f;
    private bool isCooldown = false;

>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
    void Start()
    {
        CurrentStamina = StartStamina;
        rigidbody2D = GetComponent<Rigidbody2D>();
        CurrentStamina = StartStamina;
    }
    void FixedUpdate()
    {

<<<<<<< HEAD
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
=======
        

        if (Input.GetKey("LeftShift") && CurrentStamina > 0 &&  !isCooldown)
        {
            CurrentStamina--;
            speed = 10f;
        } else if ((Input.GetKey("LeftShift") && CurrentStamina == 0)  || (Input.GetKeyUp("LeftShift") && CurrentStamina <10) ) {
            Invoke("StaminaCooldown", CooldownTime);
            isCooldown = true;
        } else
        {
            CurrentStamina++;
            speed = 7f;
        }

>>>>>>> 53b62b3d3ec3e78c50d028d45b1c18c60bf7158a
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y).normalized;

        rigidbody2D.velocity = velocity * speed;

        rigidbody2D.angularVelocity = 0.0f;  
        

    }

    private void StaminaCooldown()
    {
        isCooldown = true;

    }
   

}
