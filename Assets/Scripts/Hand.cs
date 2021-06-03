using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("Grab");
        GetComponent<AudioSource>().Play();
    }
}
