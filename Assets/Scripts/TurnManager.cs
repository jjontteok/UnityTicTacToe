using System.Runtime.CompilerServices;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    private bool isUserTurn; //1값이 user, 2값이 컴퓨터
    public bool IsUserTurn
    {
        get; set;
    }
    private void Awake()
    {
        Screen.SetResolution(400, 800, false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        IsUserTurn = true;
    }
   
}
