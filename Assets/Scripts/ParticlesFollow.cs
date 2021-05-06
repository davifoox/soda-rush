using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void FixedUpdate()
    {
        transform.position = target.position;
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        transform.rotation = target.rotation;
    }
}
