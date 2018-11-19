using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 7.0f;
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

       
        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0 &&  !isCooldown)
        {
            CurrentStamina--;
            speed = 10f;
        } else if ((Input.GetKey(KeyCode.LeftShift) && CurrentStamina == 0)  || (Input.GetKeyUp(KeyCode.LeftShift) && CurrentStamina <10) ) {
            Invoke("StaminaCooldown", CooldownTime);
            isCooldown = true;
        } else
        {
            CurrentStamina++;
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
        isCooldown = true;

    }
   

}
