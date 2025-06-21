using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private List<Cell> emptyCellList=new();
    float _time;
    private void Update()
    {
        ComputerPlayTurn();
    }
    void ComputerPlayTurn()
    {
        //Computer 차례일 때만 플레이
        if (!TurnManager.instance.IsUserTurn && !BoardManager.instance.isGameOver)
        {
            _time += Time.deltaTime;
            if (_time > 1f)
            {
                _time -= _time;
                ComputerPlay();
            }
        }
    }

    void ComputerPlay()
    {
        foreach (Cell cell in BoardManager.instance.cellList)
        {
            if (cell.value == 0)
            {
                emptyCellList.Add(cell);
            }
        }
        if (emptyCellList.Count != 0)
        {
            int rnd = Random.Range(0, emptyCellList.Count);
            emptyCellList[rnd].SetValue(2);
            emptyCellList.Clear();
        }
    }
}
