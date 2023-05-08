using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime = 0f;
    private float currentTime;

    [SerializeField]
    private TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000f) % 1000f);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
