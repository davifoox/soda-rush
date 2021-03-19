using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1000f;
    Vector3 accelerometerVector = new Vector3();
    Rigidbody2D rb;
    public float thrust = 0.1f;

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
        RotatePlayer(accelerometerVector);

        rb.AddForce(transform.up * thrust);
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        //rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }

    public void RotatePlayer(Vector3 rotationVector)
    {
        //Debug.Log(rotationVector.x);
        //transform.Rotate(new Vector3(0, 0, -rotationVector.x) * speed * Time.deltaTime);
        rb.rotation -= rotationVector.x * speed * Time.deltaTime;
    }
}
