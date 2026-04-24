using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerDisplay : MonoBehaviour
{
    TextMeshProUGUI _tmp;
    private void Start()
    {
       _tmp= GetComponent<TextMeshProUGUI>();
    }
    public void Refresh(TimerData data)
    {
        string formattedTime = FormatTime(data.TimeInSeconds);
        _tmp.SetText(formattedTime);
    }

    public static string FormatTime(int timeInSeconds) => TimeSpan.FromSeconds(timeInSeconds).ToString(@"mm\:ss");
}
