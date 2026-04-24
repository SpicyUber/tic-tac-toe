using System;
using TMPro;
using UnityEngine;

public class DisplayMatchData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _winnerText, _timeText;

    public void Refresh(MatchData data)
    {
        _timeText.SetText(TimerDisplay.FormatTime((int)data.durationInSeconds));

        if(data.winningState == BoardCellState.NONE)
        {
            _winnerText.SetText("DRAW");
            _winnerText.color = Color.lightGray;
        }
        else
        {
            _winnerText.SetText($"PLAYER {(int)data.winningState} WINS");
            _winnerText.color = Settings.Instance.Theme.GetColor(data.winningState);
        }
    }
}
