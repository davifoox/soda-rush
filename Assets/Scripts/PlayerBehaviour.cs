﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerBehaviour : MonoBehaviour
{
    Vector3 accelerometerVector = new Vector3();
    Rigidbody2D rb;

    float rotationSpeed = 400f;
    public float thrust = 5f;
    float slowDownValue = 0.2f;
    float mentosBoostValue = 5f;

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
        SlowDown();
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

    void SlowDown()
    {
        if (thrust > 0)
            thrust -= slowDownValue * Time.deltaTime;
    }

    void SpeedUp()
    {
        //Camera.main.DOComplete();
        //Camera.main.DOShakePosition(.2f, .5f, 14, 90, false);
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
            Debug.Log("Mentos!");
            SpeedUp();
        }

        if (collision.gameObject.layer == 10) // Enemy Layer
        {
            Debug.Log("Enemy!");
            HitEnemy();
        }
    }


}
