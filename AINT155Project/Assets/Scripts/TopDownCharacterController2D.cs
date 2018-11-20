using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 7.0f;
    public float sprintSpeed = 10f;
    Rigidbody2D rigidbody2D;
    public int StartStamina = 50;
    public int CurrentStamina;
    public float CooldownTime = 0.25f;
    private bool isCooldown = false;

    void Start()
    {
        CurrentStamina = StartStamina;
        rigidbody2D = GetComponent<Rigidbody2D>();
        CurrentStamina = StartStamina;
    }
    void FixedUpdate()
    {

       
        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0 && !isCooldown)
        {
            CurrentStamina--;
            speed = sprintSpeed;
        } else if ((Input.GetKey(KeyCode.LeftShift) && CurrentStamina == 0 &&   !isCooldown)  || (Input.GetKeyUp(KeyCode.LeftShift) && CurrentStamina <50) ) {
            Invoke("StaminaCooldown", CooldownTime);
            speed = 7f;
            isCooldown = true;
        } else
        {
            if (CurrentStamina < StartStamina)
            {
                CurrentStamina++;
            }
            speed = 7f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y).normalized;

        rigidbody2D.velocity = velocity * speed;

        rigidbody2D.angularVelocity = 0.0f;  
        

    }

    private void StaminaCooldown()
    {
        isCooldown = false;

    }
   

}
