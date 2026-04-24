using System;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Grid), typeof(Board), typeof(BoardView))]
public class MatchController : MonoBehaviour
{
    [Header("External Dependencies")]
    [SerializeField] TurnSystem _turnSystem;
    [SerializeField] Timer _timer;

    [Header("Parameters")]
    [SerializeField] int _boardSize=3;

    [Header("Board Cell Prefab")]
    [SerializeField] GameObject _boardCellPrefab;

    [Header("Visual Effects")]
    [SerializeField] PlaceEffectSO _placeEffect;
    [SerializeField] PlaceEffectSO _winEffect;
    [SerializeField] Material _lineEffectMaterial;

    [Header("Events")]
    [SerializeField] UnityEvent<MatchData> MatchOver;

    private Board _board;
    private BoardView _boardView;

    private void Start()
    {
        CacheComponents();
        InstantiateBoard();
        InstantiateBoardView();
    }
    public void PlaceOnBoard(Vector3 worldPosition)
    {
        if (_turnSystem.State != TurnSystemState.ACTIVE)
            return;

        var newBoardCellState = GetStateFromPlayerTurnIndex(_turnSystem.CurrentTurnPlayerIndex);

        var effect = _placeEffect;

        Vector2Int placementPositionInGrid = new();

        if(!_board.TryPlace(worldPosition, newBoardCellState, out placementPositionInGrid))
            return;

        if(_board.CheckWin(placementPositionInGrid, newBoardCellState))
        {
            EndMatch(newBoardCellState);
            DrawLine(newBoardCellState);

            ScreenShake.Instance.Shake();
            effect = _winEffect;

        }
        else if(_turnSystem.MaxTurnsReached)
        {
            EndMatch(BoardCellState.NONE);
        }

        _boardView.UpdateView(newBoardCellState, placementPositionInGrid, effect);
        _turnSystem.EndTurn();

    }

    private void DrawLine(BoardCellState winningState)
    {
        (Vector3,Vector3) furthestPoints = LineUtility.GetFurthestPoints(_board.GetWinningCellsCenterWorldPositon());
        _boardView.DrawLine(furthestPoints.Item1,furthestPoints.Item2,winningState,_lineEffectMaterial);
    }

    private void InstantiateBoardView() => _boardView.InstantiateCells(_boardCellPrefab,GetComponent<Grid>(), _boardSize);

    private void InstantiateBoard() => _board.InstantiateBoard(GetComponent<Grid>(), _boardSize);

    private void CacheComponents()
    {
        _board = GetComponent<Board>();
        _boardView = GetComponent<BoardView>();
    }

    private BoardCellState GetStateFromPlayerTurnIndex(int currentTurnPlayerIndex)
        => (_turnSystem.CurrentTurnPlayerIndex % 2 == 0) ? BoardCellState.X : BoardCellState.O;

    private void EndMatch(BoardCellState winningState) 
    {
        MatchOver?.Invoke(new()
        {
            durationInSeconds = _timer.TimeInSeconds,
            winningState = winningState
        });
    }
 
}
