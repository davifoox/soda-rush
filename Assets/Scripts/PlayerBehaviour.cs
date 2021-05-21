using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    Vector3 accelerometerVector = new Vector3();

    float thrust = 15f;
    float slowDownValue = 0.2f;
    float maxThrustSpeed = 18f;
    float gravity = 10f;

    private float screenHorizontalLimit = 3.3f;

    // EVENTS
    public delegate void PlayerSpeedUp();
    public event PlayerSpeedUp OnPlayerSpeedUp;

    public Transform pivot;

    float mentosBoostValue = 5f; //isso aqui tem que ir pro próprio mentos


    void Update()
    {
        accelerometerVector = Input.acceleration;
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        Move();
        MirrorPosition();
        SlowDown();
    }

    public void RotatePlayer()
    {
        Quaternion newRotation = Quaternion.Lerp(
            transform.rotation,
            new Quaternion(transform.rotation.x, transform.rotation.y, -accelerometerVector.x, 1f),
            1f);
        transform.rotation = newRotation;
    }

    void Move()
    {
        transform.Translate(Vector3.up * (thrust - gravity) * Time.deltaTime);
    }

    void SlowDown()
    {
        if (thrust > 0)
            thrust -= slowDownValue * Time.deltaTime;
        else
            thrust = 0;
    }

    void SpeedUp()
    {
        OnPlayerSpeedUp();
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        thrust += mentosBoostValue;
        if (thrust > maxThrustSpeed)
            thrust = maxThrustSpeed;
    }

    void HitEnemy()
    {
        thrust = -5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) // Mentos Layer
        {
            SpeedUp();
        }

        if (collision.gameObject.layer == 10) // Enemy Layer
        {
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

    void ApplyGravity()
    {

    }
}
