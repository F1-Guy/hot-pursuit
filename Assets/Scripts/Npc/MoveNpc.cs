using UnityEngine;
using Math = System.Math;

public class MoveNpc : MonoBehaviour
{
    public enum Direction
    {
        Down = -1,
        Up = 1
    }

    public Direction direction;

    public float speed = 2f;

    Vector2 initalPosition;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y += speed * Time.deltaTime * speed * (int)direction;

        if (Math.Abs(position.y) > 8) Destroy(this.gameObject);

        else transform.position = position;
    }
}
