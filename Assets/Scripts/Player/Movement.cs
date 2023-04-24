using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private int bound = 6;

    [SerializeField]
    float Speed = 10f;

    // [SerializeField]
    // float acceleration = 1;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        position.x += h * Time.deltaTime * Speed;

        if (position.x < -bound) position.x = -bound;
        if (position.x > bound) position.x = bound;

        transform.position = position;
    }
}
