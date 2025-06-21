using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button restartButton;
    public TMP_Text gameStatusText;
    public GameObject gameOverPanel;
    private void OnEnable()
    {
        Debug.Log(BoardManager.instance == null ? "BoardManager.instance is NULL" : "BoardManager.instance is OK");
        if (BoardManager.instance != null)
        {
            BoardManager.instance.OnGameFinished += OnGameFinished;
            BoardManager.instance.OnReset += ResetUI;
        }
    }

    private void OnDisable()
    {
        BoardManager.instance.OnGameFinished -= OnGameFinished;
        BoardManager.instance.OnReset -= ResetUI;
    }

    void Start()
    {
        restartButton.onClick.AddListener(OnRestartClick);
    }

    void OnGameFinished(int value, bool isWin)
    {
        gameOverPanel.SetActive(true);
        if (isWin)
        {
            string winner = value == 1 ? "You" : "Computer";
            gameStatusText.color = value == 1 ? Color.magenta : Color.cyan;
            gameStatusText.text = $"{winner} Wins!";
        }
        else
        {
            gameStatusText.color = Color.yellow;
            gameStatusText.text = "Draw! Try Again";
        }
    }

    void ResetUI()
    {
        gameOverPanel.SetActive(false);
        gameStatusText.text = "";
    }

    void OnRestartClick()
    {
        BoardManager.instance.ResetGame();
    }
}
