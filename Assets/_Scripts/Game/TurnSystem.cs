using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TurnSystem : MonoBehaviour
{
    [SerializeField] private int _playerCount = 2;
    [SerializeField] private bool _hasMaxTurns = true;
    [SerializeField] private int _maxTurns = 9;
    [SerializeField] UnityEvent<PlayerTurnsInfo> _turnEnded;
    [SerializeField] private float _delayInSeconds = 2f;

    private int[] _playerTurnCounts;
    private int _totalTurnCounts = 1;
    private int _currentTurnPlayerIndex;

    public int CurrentTurnPlayerIndex { get => _currentTurnPlayerIndex; }
    public bool MaxTurnsReached { get => _totalTurnCounts >= _maxTurns; }
    public TurnSystemState State { get; private set; }


    private void Start()
    {
        _currentTurnPlayerIndex = 0;

        _playerTurnCounts = new int[_playerCount];

        IncrementTurnCountForPlayerAt(_currentTurnPlayerIndex);

        InvokeTurnEndedEvent();
    }

    public int GetTurnCountForPlayer(int playerIndex)=>_playerTurnCounts[playerIndex];

    [ContextMenu("End Turn")]
    public void EndTurn()
    {
        if (MaxTurnsReached || State==TurnSystemState.TRANSITIONING) return;

        State = TurnSystemState.TRANSITIONING;

        StopAllCoroutines();
        StartCoroutine(EndTurnCoroutine());
    }

    public IEnumerator EndTurnCoroutine()
    {
        yield return new WaitForSeconds(_delayInSeconds);

        IncrementCurrentPlayerIndex();

        IncrementTurnCountForPlayerAt(_currentTurnPlayerIndex);

        State = TurnSystemState.ACTIVE;

        InvokeTurnEndedEvent();

        _totalTurnCounts++;
    }

    private void InvokeTurnEndedEvent() 
        => _turnEnded?.Invoke(
            new()
            {
                TotalTurnCountForNextPlayer = _playerTurnCounts[_currentTurnPlayerIndex],
                NextPlayerIndex = _currentTurnPlayerIndex
            });

    private void IncrementTurnCountForPlayerAt(int currentTurnPlayerIndex) => _playerTurnCounts[_currentTurnPlayerIndex]++;
    
    private void IncrementCurrentPlayerIndex() => _currentTurnPlayerIndex = (_currentTurnPlayerIndex + 1) % _playerCount;

}
