using System;
using UnityEngine;

//value 0: 비어있는 셀
//value 1: 플레이어 셀
//value 2: 컴퓨터 셀

public class Cell : MonoBehaviour
{
    public int value { get; set; }
    public bool IsInteractive { get; set; }

    public Action<int> OnCellValueChanged;
   
    void Start()
    {
        value = 0; //셀의 초기값은 0(비어있는 셀)으로 설정
        IsInteractive = true;
    }

    //셀에 값을 넣는 함수
    public void SetValue(int newValue)
    {
        value = newValue;
        OnCellValueChanged?.Invoke(value); //셀의 값이 바뀌었으니 이벤트 함수 호출
    }

    //결과를 설정하는 함수
    public void SetResult(bool isWin)
    {
        IsInteractive = false;
    }

    // 셀 초기화하는 함수
    public void Reset()
    {
        IsInteractive = true;
        SetValue(0); 
    }
}
