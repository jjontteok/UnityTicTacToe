using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;
    public event Action<int, bool> OnGameFinished;
    public event Action OnReset;

    public bool isGameOver = false;

    public List<Cell> cellList = new List<Cell>();

    private readonly int[][] winConditions =
    {
        new[] {0, 1, 2 },   //winConditions[0]
        new[] {3, 4, 5 },   //1
        new[] {6, 7, 8 },   //2
        new[] {0, 3, 6 },   //3
        new[] {1, 4, 7 },   //4
        new[] {2, 5, 8 },   //5
        new[] {0, 4, 8 },   //6
        new[] {2, 4, 6 }    //7
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("BoardManager instance is set.");
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        foreach (var cell in cellList) cell.OnCellValueChanged += CheckWinCondition;
    }

    private void OnDisable()
    {
        foreach (var cell in cellList) cell.OnCellValueChanged -= CheckWinCondition;
    }
    
    private void Start()
    {
        ResetGame();
    }

    //셀의 값이 바뀌면 호출될 함수
    private void CheckWinCondition(int value)
    {
        foreach(var condition in winConditions)
        {
            if (cellList[condition[0]].value==value&&
                cellList[condition[1]].value==value&&
                cellList[condition[2]].value==value&&
                value != 0)
            {
                OnGameFinished?.Invoke(value, true);
                return;
            }
        }
        var allCellFilled = true;
        foreach(var cell in cellList)
        {
            if (cell.value == 0)
            {
                allCellFilled = false;
                break;
            }
        }
        if (allCellFilled)
        {
            OnGameFinished?.Invoke(0, false);
        }
    }
    public void ResetGame()
    {
        TurnManager.instance.IsUserTurn = true;
        isGameOver = false;
        foreach(var cell in cellList)
        {
            cell.Reset();
        }
        OnReset?.Invoke();
    }

}
