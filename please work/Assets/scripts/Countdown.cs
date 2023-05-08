using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float totalTime = 60f; // total time for countdown in seconds
    public TextMeshProUGUI countdownText; // reference to the UI text component to display the countdown

    private float timeRemaining; // current time remaining for countdown

    void Start()
    {
        timeRemaining = totalTime; // initialize the time remaining to the total time
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime; // subtract the time since the last frame from the time remaining

        if (timeRemaining <= 0f)
        {
            // the countdown has finished
            timeRemaining = 0f;
            countdownText.text = "Time's up!";
        }
        else
        {
            // display the time remaining in minutes and seconds
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }
}
