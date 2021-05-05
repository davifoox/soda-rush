using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentosBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) // Player Layer
        {
            Destroy(this.gameObject);
        }
    }
}
