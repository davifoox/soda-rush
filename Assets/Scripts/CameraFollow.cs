using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] PlayerBehaviour player;
    int offset = 2;

    public delegate void PlayerLeftScreen();
    public event PlayerLeftScreen OnPlayerLefScreen;

    void FixedUpdate()
    {
        if (player.transform.position.y + offset > this.transform.position.y)
            this.transform.position = new Vector3(0, player.transform.position.y + offset, this.transform.position.z);
        else if (player.transform.position.y < this.transform.position.y - 5)
        {
            Debug.Log("Player out of Screen!");
            OnPlayerLefScreen();
        }


        //Debug.Log("Player posiiton: " + target.transform.position.y);
        //Debug.Log("Camera posiiton: " + this.transform.position.y);
    }

    private void OnEnable()
    {
        player.OnPlayerSpeedUp += ShakeCamera;
    }

    private void OnDisable()
    {
        player.OnPlayerSpeedUp -= ShakeCamera;
    }

    void ShakeCamera()
    {
        Debug.Log("Shaking Camera...");
    }
}
