using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;


public class Board : MonoBehaviour
{
    public int BoardSize { get => _boardStates.GetLength(0); }  

    private BoardCellState[,] _boardStates;

    private Grid _grid;

    private bool _instantiated = false;

    private Vector2Int[] _winningCells;

    public void InstantiateBoard(Grid grid, int boardSize)
    {
        if (_instantiated) return;
        _instantiated = true;

        InitializeBoardState(boardSize);
        InitializeWinningCellArray(boardSize);
        CacheGrid(grid);
    }

    public bool TryPlace(Vector3 worldPos, BoardCellState boardCellState,out Vector2Int gridPosition)
    {
        var cellPositionWithY = _grid.WorldToCell(worldPos);
        gridPosition = new Vector2Int(cellPositionWithY.x, cellPositionWithY.z);
        
        if(IsInBoard(gridPosition) && !CellTaken(gridPosition)) 
        {
            Place(gridPosition, boardCellState);
            return true;
        }

        return false;
    }

    public bool CheckWin(Vector2Int pos, BoardCellState state)
    {
        var winningCells = new Vector2Int[_winningCells.Length];

        bool win = 
            CheckRow(pos.y, state, winningCells)
            || CheckColumn(pos.x, state, winningCells)
            || CheckMainDiagonal(pos, state, winningCells)
            || CheckAntiDiagonal(pos, state, winningCells);

        if(!win) ClearWinningCells();

        return win;
    }

    public Vector3[] GetWinningCellsCenterWorldPositon()
    {
        Vector3[] winningCellsWorldPosition = new Vector3[_winningCells.Length];

        for(int i = 0; i < _winningCells.Length; i++)
        {
            Vector3Int threeDimensionalCellPosition = new(_winningCells[i].x, 0, _winningCells[i].y);
            winningCellsWorldPosition[i] = _grid.GetCellCenterWorld(threeDimensionalCellPosition);
        }
            
        return winningCellsWorldPosition;
    }  

    private void ClearWinningCells()
    {
        for(int i=0; i<_winningCells.Length; i++)
        {
            _winningCells[i] = new(-1, -1);
        }
            
    }

    private bool CheckRow(int y, BoardCellState state, Vector2Int[] winningCells)
    {
        

        for (int x = 0; x < BoardSize; x++)
        {
            winningCells[x] = new(x, y);

            if (_boardStates[x, y] != state)
                return false;
        }

        _winningCells = winningCells;

        return true;
    }

    private bool CheckColumn(int x, BoardCellState state, Vector2Int[] winningCells)
    {
        for (int y = 0; y < BoardSize; y++)
        {
            winningCells[y] = new(x, y);

            if (_boardStates[x, y] != state)
                return false;
        }

        _winningCells = winningCells;

        return true;
    }

    private bool CheckMainDiagonal(Vector2Int pos, BoardCellState state, Vector2Int[] winningCells)
    {
        if (pos.x != pos.y) return false;

        for (int i = 0; i < BoardSize; i++)
        {
            winningCells[i] = new(i, i);

            if (_boardStates[i, i] != state)
                return false;
        }

        _winningCells = winningCells;

        return true;
    }

    private bool CheckAntiDiagonal(Vector2Int pos, BoardCellState state, Vector2Int[] winningCells)
    {
        if (pos.x + pos.y != BoardSize - 1) return false;

        for (int i = 0; i < BoardSize; i++)
        {
            winningCells[i] = new(i, BoardSize - 1 - i);

            if (_boardStates[i, BoardSize - 1 - i] != state)
                return false;
        }

        _winningCells = winningCells;

        return true;
    }

    private void InitializeWinningCellArray(int boardSize)
    {
        var arr = new Vector2Int[boardSize];

        for(int i = 0; i < boardSize; i++)
            arr[i] = new Vector2Int(-1, -1);

        _winningCells = arr;
    }

    private bool CellTaken(Vector2Int gridPosition)
    => _boardStates[gridPosition.x, gridPosition.y] != BoardCellState.NONE;
    private void InitializeBoardState(int boardSize) => _boardStates = new BoardCellState[boardSize, boardSize];

    private void CacheGrid(Grid grid) => _grid = grid;


    private void Place(Vector2Int gridPosition, BoardCellState newState)
    {
        _boardStates[gridPosition.x, gridPosition.y] = newState;
    }

    private bool IsInBoard(Vector2Int gridPosition)
        => (gridPosition.x < BoardSize && gridPosition.y < BoardSize) && (gridPosition.x >= 0 && gridPosition.y >= 0);
}
