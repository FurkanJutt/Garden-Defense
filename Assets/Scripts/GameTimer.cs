using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Timer In Seconds")]
    [SerializeField] float levelTime = 10f;

    private bool timerTriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (timerTriggered) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timeEnded = Time.timeSinceLevelLoad >= levelTime;
        if (timeEnded)
        {
            FindObjectOfType<LevelControler>().LevelTimerEnded();
            timerTriggered = true;
        }
    }

    public void SetLevelTime(float time)
    {
        levelTime = time;
    }
}
