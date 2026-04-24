using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] UnityEvent<TimerData> _secondPassed;

    public int TimeInSeconds => (int)_timeInSeconds;

    private bool _isTicking = false;
    private float _timeInSeconds;

    void Update() => Tick();

    public void Tick()
    {
        if(!_isTicking) return;

        float newTimeInSeconds = _timeInSeconds + Time.deltaTime;

        if((int)newTimeInSeconds > (int)_timeInSeconds)
            _secondPassed?.Invoke(
                new()
                {
                    TimeInSeconds = TimeInSeconds
                });

        _timeInSeconds = newTimeInSeconds;
    }

    public void StartTimer() => _isTicking = true;

    public void StopTimer() => _isTicking = false;

    public void ResetTimer()
    {
        _timeInSeconds = 0;
        _isTicking = true;
    }

}
