using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    Vector3 accelerometerVector = new Vector3();
    Rigidbody2D rb;

    public float thrust = 5f;
    float slowDownValue = 0.3f;
    float rotationSpeed = 350f;

    float mentosBoostValue = 5f; //isso aqui tem que ir pro próprio mentos

    private float screenHorizontalLimit = 3.3f;

    public delegate void PlayerSpeedUp();
    public event PlayerSpeedUp OnPlayerSpeedUp;

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
        Move();
        MirrorPosition();
        SlowDown();

        //Debug.Log(accelerometerVector.x);
    }

    public void RotatePlayer(Vector3 rotationVector)
    {
        float normalRotationLimit = 10f;
        if (transform.rotation.z < normalRotationLimit && transform.rotation.z > -normalRotationLimit)
            rb.rotation -= rotationVector.x * rotationSpeed * Time.deltaTime;
        //else
        //    rb.rotation -= rotationVector.x * (rotationSpeed - 100) * Time.deltaTime;

    }

    void Move()
    {
        rb.velocity = transform.TransformDirection(new Vector2(0, thrust));
    }

    void SlowDown()
    {
        if (thrust > 0)
            thrust -= slowDownValue * Time.deltaTime;
    }

    void SpeedUp()
    {
        OnPlayerSpeedUp();
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        thrust += mentosBoostValue;
        if (thrust > 10f)
            thrust = 10f;
    }

    void HitEnemy()
    {
        thrust = -5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) // Mentos Layer
        {
            //Debug.Log("Mentos!");
            SpeedUp();
        }

        if (collision.gameObject.layer == 10) // Enemy Layer
        {
            //Debug.Log("Enemy!");
            HitEnemy();
        }
    }

    void MirrorPosition()
    {
        if (transform.position.x > screenHorizontalLimit)
        {
            transform.position = new Vector2(-screenHorizontalLimit, transform.position.y);
        }
        else if (transform.position.x < -screenHorizontalLimit)
        {
            transform.position = new Vector2(screenHorizontalLimit, transform.position.y);
        }
    }
}
