using TMPro;
using UnityEngine;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI P1Wins, P2Wins,Draws,AverageGameDuration;

    private void OnEnable()
    {
        if (!Stats.Instance) return;
        P1Wins.text = Stats.Instance.Player1WinCount.ToString();
        P2Wins.text = Stats.Instance.Player2WinCount.ToString(); 
        Draws.text = Stats.Instance.Player2WinCount.ToString(); 
        AverageGameDuration.text = $"{Mathf.FloorToInt(Stats.Instance.AverageGamesDuration / 60)} mins";

    }
}
