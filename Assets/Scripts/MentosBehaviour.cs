using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
