using System;
using UnityEngine;

//value 0: ����ִ� ��
//value 1: �÷��̾� ��
//value 2: ��ǻ�� ��

public class Cell : MonoBehaviour
{
    public int value { get; set; }
    public bool IsInteractive { get; set; }

    public Action<int> OnCellValueChanged;
   
    void Start()
    {
        value = 0; //���� �ʱⰪ�� 0(����ִ� ��)���� ����
        IsInteractive = true;
    }

    //���� ���� �ִ� �Լ�
    public void SetValue(int newValue)
    {
        value = newValue;
        OnCellValueChanged?.Invoke(value); //���� ���� �ٲ������ �̺�Ʈ �Լ� ȣ��
    }

    //����� �����ϴ� �Լ�
    public void SetResult(bool isWin)
    {
        IsInteractive = false;
    }

    // �� �ʱ�ȭ�ϴ� �Լ�
    public void Reset()
    {
        IsInteractive = true;
        SetValue(0); 
    }
}
