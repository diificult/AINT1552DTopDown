using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour {

    public UnityEvent onTimerComplete;

    public bool  isSpawning  = false;

    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            float time = Random.Range(0.1f, 4.5f);
            Invoke("OnTimerComplete", time);
        }
    }
    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
        isSpawning = false;
    }
}
