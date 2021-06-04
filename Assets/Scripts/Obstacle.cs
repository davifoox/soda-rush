using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player;
    private float offset = 5f;
    private BoxCollider2D boxCollider2D;
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        player = FindObjectOfType<LevelManager>().player;
        boxCollider2D = GetComponent<BoxCollider2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();

        player.OnPlayerGotInvincible += ChangeCollisionToTrigger;
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
        if(boxCollider2D != null)
            boxCollider2D.isTrigger = value;
        else if (circleCollider2D != null)
            circleCollider2D.isTrigger = value;
    }
}
