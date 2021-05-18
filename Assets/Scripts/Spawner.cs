using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; // alterar para Enemy quando criar o script dele
    [SerializeField] MentosBehaviour mentos;
    [SerializeField] PlayerBehaviour player;
    private float offset = 15f;

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x, player.transform.position.y + offset);
    }
}
