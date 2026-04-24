using UnityEngine;

public class TimerLifecycleBinder : MonoBehaviour
{
    [SerializeField] Timer _timer;

    private void OnEnable()=>_timer.StartTimer();

    private void OnDisable()=>_timer.StopTimer();
    
      
    



}
