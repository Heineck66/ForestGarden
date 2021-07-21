using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField, Tooltip("Lavel timer in SECONDS")] float levelTimer = 10f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }

    }
}
