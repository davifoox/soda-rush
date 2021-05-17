using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.y;
        lenght = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log("LENGHT: " + lenght);
    }

    private void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + lenght) startPos += lenght;
        else if (temp < startPos - lenght) startPos -= lenght;
    }
}
