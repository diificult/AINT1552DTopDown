using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D: MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(x, y).normalized;

        rigidbody2D.velocity = velocity * speed;

        rigidbody2D.angularVelocity = 0.0f;
    }
}
