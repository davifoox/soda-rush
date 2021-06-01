using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;
    private float offset = 5f;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        player.OnPlayerGotInvincible += ChangeCollisionToTrigger;
    }

    private void OnDisable()
    {
        
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y > this.transform.position.y + offset)
            Destroy(this.gameObject);
    }

    void ChangeCollisionToTrigger(bool value)
    {
        boxCollider2D.isTrigger = value;
    }
}
