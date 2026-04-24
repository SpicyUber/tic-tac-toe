using TMPro;
using UnityEngine;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI P1Wins, P2Wins,Draws,AverageGameDuration, TotalMatchesCount;

    private void OnEnable()
    {
        if (!Stats.Instance) return;
        P1Wins.text = Stats.Instance.Player1WinCount.ToString();
        P2Wins.text = Stats.Instance.Player2WinCount.ToString(); 
        Draws.text = Stats.Instance.DrawCount.ToString(); 
        AverageGameDuration.text = TimerDisplay.FormatTime((int)Stats.Instance.AverageGamesDurationInSeconds);
        TotalMatchesCount.text = Stats.Instance.GamesPlayed.ToString();
    }
}
