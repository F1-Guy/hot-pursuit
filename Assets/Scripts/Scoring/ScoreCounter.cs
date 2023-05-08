using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int Score = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = Score.ToString();
    }
}
