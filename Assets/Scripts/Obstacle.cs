using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;
    private float offset = 5f;
    private BoxCollider2D boxCollider2D;

    public void Initialize(Player currentPlayer)
    {
        player = currentPlayer;
        boxCollider2D = GetComponent<BoxCollider2D>();
        currentPlayer.OnPlayerGotInvincible += ChangeCollisionToTrigger;
        if (player.isInvincible)
            ChangeCollisionToTrigger(false);
    }

    private void OnDestroy()
    {
        player.OnPlayerGotInvincible -= ChangeCollisionToTrigger;
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y > this.transform.position.y + offset)
            Destroy(this.gameObject);
    }

    public void ChangeCollisionToTrigger(bool value)
    {
        boxCollider2D.isTrigger = value;
    }
}
