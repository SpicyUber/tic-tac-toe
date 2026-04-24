using System;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerTurnDisplay : MonoBehaviour
{
    [SerializeField] int _playerIndex;
    TextMeshProUGUI _tmp;
    private int _turnCount = 0;
    private Color _color;
    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        _color = Settings.Instance.Theme.GetColor(_playerIndex);
        _tmp.color = _color;
        UpdateText();
    }

    public void Refresh(PlayerTurnsInfo data)
    {
        if(data.NextPlayerIndex == _playerIndex)
        {
            _turnCount = data.TotalTurnCountForNextPlayer;
            Highlight();
            UpdateText();
        }
        else
        {
            UnHighlight();
            HideTurns();
        }

    }

    private void HideTurns() => _tmp.SetText($"P{_playerIndex + 1}\nWaiting");

    private void UpdateText() => _tmp.SetText($"P{_playerIndex + 1}\nTurn : {_turnCount}");

    private void UnHighlight() => _tmp.color = _color * new Color(0.5f, 0.5f, 0.5f);

    private void Highlight() => _tmp.color = _color;

}
