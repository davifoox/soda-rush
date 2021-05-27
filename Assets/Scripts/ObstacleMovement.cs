using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float screenLimit = 6f;
    float speed = -2.5f;

    private void FixedUpdate()
    {
        if (transform.position.x > screenLimit)
        {
            speed = Mathf.Abs(speed) * -1;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(transform.position.x < -screenLimit)
        {
            speed = Mathf.Abs(speed);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }

        transform.Translate(new Vector2(speed * Time.deltaTime ,0f));
    }
}
