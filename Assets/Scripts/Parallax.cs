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
        lenght = GetComponent<SpriteRenderer>().bounds.size.y;// * 0.78f; // 0.78f é o quanto o sprite de bg foi escalado pra ficar exatamente igual a camera
        Debug.Log("LENGHT: " + lenght);
    }

    private void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + lenght - 5) startPos += lenght; //- 5 é por causa do offset da latinha com a camera (não fica exatamente no centro)
        else if (temp < startPos - lenght + 5) startPos -= lenght;
    }
}
