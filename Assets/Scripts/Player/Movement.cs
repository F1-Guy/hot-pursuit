using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private int bound = 6;

    [SerializeField]
    float Speed = 10f;

    [SerializeField]
    Collider2D playerCollider;

    [SerializeField]
    GameObject EndScreen;

    GameObject[] colliders;

    // [SerializeField]
    // float acceleration = 1;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        colliders = GameObject.FindGameObjectsWithTag("Npc");

        float h = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        position.x += h * Time.deltaTime * Speed;

        if (position.x < -bound) position.x = -bound;
        if (position.x > bound) position.x = bound;

        transform.position = position;

        foreach (var car in colliders)
        {
            if (playerCollider.bounds.Intersects(car.GetComponent<Collider2D>().bounds))
            {
                EndScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
