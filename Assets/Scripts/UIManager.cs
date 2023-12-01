using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{

    [SerializeField] private CanvasRenderer gameOverPanel;
    [SerializeField] private CanvasRenderer newGamePanel;
    [SerializeField] private CanvasRenderer youWinPanel;
    [SerializeField] private CanvasRenderer scorePanel;
    [SerializeField] private TextMeshProUGUI scoreField;

    public void Initialize(TextMeshProUGUI _scoreField)
    {
        scoreField = _scoreField;
    }


    public void DisplayGameOverPanel(bool visible)
    {
        gameOverPanel.gameObject.SetActive(visible);
    }


    public void DisplayNewGamePanel(bool visible)
    {
        newGamePanel.gameObject.SetActive(visible);
    }


    public void DisplayYouWinPanel(bool visible)
    {
        youWinPanel.gameObject.SetActive(visible);
    }


    public void DisplayScore(int score)
    {
        scoreField.text = "Score : " + score;
    }

    public void Replay()
    {
        DisplayGameOverPanel(false);
        DisplayYouWinPanel(false);
        GameManager.Instance.Replay();
    }


}
