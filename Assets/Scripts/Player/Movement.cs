using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frameh
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        position.x += h * Time.deltaTime * speed;

        transform.position = position;
    }
}
