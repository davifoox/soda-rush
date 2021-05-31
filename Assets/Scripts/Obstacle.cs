using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform player;
    private float offset = 5f;

    private void FixedUpdate()
    {
        if (player.position.y > this.transform.position.y + offset)
            Destroy(this.gameObject);
    }
}
