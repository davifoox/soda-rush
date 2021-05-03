using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float rotationSpeed = 500f;
    Vector3 accelerometerVector = new Vector3();
    Rigidbody2D rb;
    public float thrust = 2f;//5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        accelerometerVector = Input.acceleration;
    }

    private void FixedUpdate()
    {
        /*
        if (SystemInfo.operatingSystem.Contains("Android"))
            RotatePlayer(accelerometerVector);
        else // if it's running on Windows
        {
            Vector2 inputVector;
            if (Input.GetKey(KeyCode.LeftArrow))
                inputVector = new Vector2(-1, 0);
            else if (Input.GetKey(KeyCode.RightArrow))
                inputVector = new Vector2(1, 0);
            else
                inputVector = new Vector2(0, 0);

            RotatePlayer(inputVector);
        }
        */

        RotatePlayer(accelerometerVector);
        Move();
    }

    public void RotatePlayer(Vector3 rotationVector)
    {
        rb.rotation -= rotationVector.x * rotationSpeed * Time.deltaTime;
    }

    void Move()
    {
        rb.velocity = transform.TransformDirection(new Vector2(0,thrust));
        //rb.velocity = new Vector2(0, thrust);

        //rb.AddForce(transform.up * thrust);
        //rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }
}
