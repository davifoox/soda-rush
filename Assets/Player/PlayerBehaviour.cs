using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 1000f;
    Vector3 accelerometerVector = new Vector3();

    void Update()
    {
        accelerometerVector = Input.acceleration;
    }

    private void FixedUpdate()
    {
        RotatePlayer(accelerometerVector);
    }

    public void RotatePlayer(Vector3 rotationVector)
    {
        Debug.Log(rotationVector.x);
        transform.Rotate(new Vector3(0, 0, -rotationVector.x) * speed * Time.deltaTime);
    }
}
