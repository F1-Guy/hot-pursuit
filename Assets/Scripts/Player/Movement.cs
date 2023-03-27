using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private int bound = 6;

    public float speed = 10f;

    [SerializeField]
    private float acceleration = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        position.x += h * Time.deltaTime * speed;

        if (position.x < -bound) position.x = -bound;
        if (position.x > bound) position.x = bound;

        transform.position = position;
    }
}
