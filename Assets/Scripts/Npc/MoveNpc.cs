using UnityEngine;
using Math = System.Math;
using Random = UnityEngine.Random;

public class MoveNpc : MonoBehaviour
{
    public enum Direction
    {
        Down = -1,
        Up = 1
    }

    [SerializeField]
    Direction direction;

    [SerializeField]
    float AverageSpeed = 2f;

    [SerializeField]
    static float CountThreshold = 5f;

    static float SpeedVariation = 0.2f;

    float speed;

    Vector2 initalPosition;

    bool Counted = false;

    void Start()
    {
        if (SpeedVariation > AverageSpeed)
        {
            Debug.LogWarning("Speed variation cannot be greater than average speed. Variation set to 0.");
            SpeedVariation = 0;
            return;
        }

        speed = Random.Range(AverageSpeed - SpeedVariation, AverageSpeed + SpeedVariation);
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.y += speed * Time.deltaTime * speed * (int)direction;

        if (position.y < -CountThreshold && !Counted)
        {
            GameObject.FindGameObjectWithTag("Counter").GetComponent<ScoreCounter>().Score++;
            Counted = true;
        }

        if (Math.Abs(position.y) > 8)
        {
            Destroy(this.gameObject);
        }

        else transform.position = position;
    }
}
