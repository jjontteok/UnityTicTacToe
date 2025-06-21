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
        //newValue�� 0(��� �ְų�), 1(user �����̰ų�), 2(computer �����̰ų�)
        cellButton.image.color = newValue == 1 ? Color.magenta : Color.cyan;
        if (newValue == 1)
            TurnManager.instance.IsUserTurn = false;
        else if(newValue==2)
            TurnManager.instance.IsUserTurn = true;
        if (newValue != 0) return;
        //newValue�� 0�̶��
        cellButton.image.color = Color.white;
    }

    //�� ��ư�� Ŭ������ �� ȣ��Ǵ� �Լ�
    void OnCellButtonClick()
    {
        if (!cell.IsInteractive) return; //cell�� ��Ȱ��ȭ ���¸� ����
        if (cell.value == 0)            //���� ������� ���� ���� ���� �ִ´�.
        {
            cell.SetValue(1);
        }
    }
}
