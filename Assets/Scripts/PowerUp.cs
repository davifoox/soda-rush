using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string mentosColor;
    public Transform player;

    private void FixedUpdate()
    {
        if(player.position.y > this.transform.position.y + 5f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) // Player Layer
        {
            Destroy(this.gameObject);
        }
    }
}
