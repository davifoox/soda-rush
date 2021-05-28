using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform player;

    private void FixedUpdate()
    {
        if (player.position.y > this.transform.position.y + 5f)
            Destroy(this.gameObject);
    }
}
