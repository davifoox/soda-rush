using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        if(target.position.y > this.transform.position.y)
            this.transform.position = new Vector3(0, target.position.y, this.transform.position.z);
    }
}
