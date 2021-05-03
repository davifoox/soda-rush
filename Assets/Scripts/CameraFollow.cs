using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    int offset = 2;

    void FixedUpdate()
    {
        if(target.position.y + offset > this.transform.position.y)
            this.transform.position = new Vector3(0, target.position.y + offset, this.transform.position.z);
    }
}
