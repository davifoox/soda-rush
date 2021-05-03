using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    int offset = 2;

    public delegate void PlayerLeftScreen();
    public event PlayerLeftScreen OnPlayerLefScreen;

    void FixedUpdate()
    {
        if (target.position.y + offset > this.transform.position.y)
            this.transform.position = new Vector3(0, target.position.y + offset, this.transform.position.z);
        else if (target.position.y + 5 < this.transform.position.y)
        {
            Debug.Log("Player out of Screen!");
            OnPlayerLefScreen();
        }
        //Debug.Log("Player posiiton: " + target.transform.position.y);
        //Debug.Log("Camera posiiton: " + this.transform.position.y);
    }
}
