using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl2D : MonoBehaviour {

    private float pitch = 0.0F;
    private float yaw = 0.0F;
    public Rigidbody2D hero;
    public float adjustmentAngle = 0.0f;
    public float smoothing = 5.0f;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() 
    {
       pitch += Input.GetAxis("Mouse Y");
       yaw += Input.GetAxis("Mouse X");

                if (pitch > 5) pitch = 5;
                if (pitch < -5) pitch = -5;
                if (yaw > 5) yaw = 5;
                if (yaw < -5) yaw = -5;

        Vector3 direction = new Vector3(yaw, pitch, 0);
        
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
    }

}
