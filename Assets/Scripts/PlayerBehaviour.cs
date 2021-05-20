using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    Vector3 accelerometerVector = new Vector3();
    Rigidbody2D rb;

    public float thrust = 5f;
    float slowDownValue = 0.2f;
    float rotationSpeed = 1f;
    float maxThrustSpeed = 8f;

    float timeToCenterRotation = 0.5f;
    float timeLeftToCenterRotation;

    float mentosBoostValue = 2f; //isso aqui tem que ir pro próprio mentos

    private float screenHorizontalLimit = 3.3f;

    public delegate void PlayerSpeedUp();
    public event PlayerSpeedUp OnPlayerSpeedUp;

    public Transform pivot;

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
        RotatePlayer();
        Move();
        MirrorPosition();
        SlowDown();

        //Debug.Log(rb.rotation);
        //Debug.Log(accelerometerVector.x);
    }

    public void RotatePlayer()
    {
        float centerRegion = 0.1f;
        float centerForce = 0.005f;
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -(rotationSpeed * accelerometerVector.x), 1f), 1f);
        transform.rotation = newRotation;
        /*
        if (accelerometerVector.x < centerRegion && accelerometerVector.x > -centerRegion)
        {
            timeLeftToCenterRotation -= Time.deltaTime;
            if (timeLeftToCenterRotation < 0) //SNAP
            {
                //rb.rotation = Mathf.Lerp(rb.rotation, 0f, 0.1f);
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, 1f);
                Quaternion centeredRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, 1f);
                transform.rotation = Quaternion.Lerp(transform.rotation, centeredRotation, Time.time * centerForce);
            }
            else //ROTATE
            {
                //rb.rotation -= accelerometerVector.x * rotationSpeed * Time.deltaTime;
                Quaternion newRotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -(rotationSpeed * accelerometerVector.x), 1f), 1f);
                transform.rotation = newRotation;
            }
        }
        else //ROTATE
        {
            timeLeftToCenterRotation = timeToCenterRotation;
            //rb.rotation -= accelerometerVector.x * rotationSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -(rotationSpeed * accelerometerVector.x), 1f), 1f);
            transform.rotation = newRotation;
        }
        */
    }

    void Move()
    {
        //rb.velocity = transform.TransformDirection(new Vector2(0, thrust));
        transform.Translate(Vector3.up * thrust * Time.deltaTime);
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
