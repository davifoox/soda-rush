using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    int offset = 2;

    public delegate void PlayerLeftScreen();
    public event PlayerLeftScreen OnPlayerLefScreen;

    private float screenHorizontalLimit = 3.3f;

    void FixedUpdate()
    {
        if (target.position.y + offset > this.transform.position.y)
            this.transform.position = new Vector3(0, target.position.y + offset, this.transform.position.z);
        else if (target.position.y < this.transform.position.y - 5)
        {
            Debug.Log("Player out of Screen!");
            OnPlayerLefScreen();
        }

        MirrorPosition();
        //Debug.Log("Player posiiton: " + target.transform.position.y);
        //Debug.Log("Camera posiiton: " + this.transform.position.y);
    }

    void MirrorPosition()
    {

        if (target.transform.position.x > screenHorizontalLimit)
        {
            target.transform.position = new Vector2(-screenHorizontalLimit, target.transform.position.y);
        }
        else if(target.transform.position.x < -screenHorizontalLimit)
        {
            target.transform.position = new Vector2(screenHorizontalLimit, target.transform.position.y);
        }
    }
}
