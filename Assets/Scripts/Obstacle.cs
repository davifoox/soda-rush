using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        Destroy(this.gameObject, 20f);
    }
}
