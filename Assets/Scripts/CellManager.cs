using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    Cell cell;
    public Button cellButton;

    private void OnEnable()
    {
        if (cell == null) cell = GetComponent<Cell>();
        cell.OnCellValueChanged += OnCellValueChanged;
    }
    private void OnDisable()
    {
        cell.OnCellValueChanged -= OnCellValueChanged;
    }

    void Start()
    {
        cellButton.onClick.AddListener(OnCellButtonClick);
    }

    void OnCellValueChanged(int newValue)
    {
        //newValue는 0(비어 있거나), 1(user 차례이거나), 2(computer 차례이거나)
        cellButton.image.color = newValue == 1 ? Color.magenta : Color.cyan;
        if (newValue == 1)
            TurnManager.instance.IsUserTurn = false;
        else if(newValue==2)
            TurnManager.instance.IsUserTurn = true;
        if (newValue != 0) return;
        //newValue가 0이라면
        cellButton.image.color = Color.white;
    }

    //셀 버튼이 클릭됐을 때 호출되는 함수
    void OnCellButtonClick()
    {
        if (!cell.IsInteractive) return; //cell이 비활성화 상태면 리턴
        if (cell.value == 0)            //셀이 비어있을 때만 셀에 값을 넣는다.
        {
            cell.SetValue(1);
        }
    }
}
