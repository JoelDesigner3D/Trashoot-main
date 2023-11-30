using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private CanvasRenderer gameOverPanel;
    [SerializeField] private CanvasRenderer newGamePanel;
    [SerializeField] private CanvasRenderer youWinPanel;

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


    public void DisplayScorePanel(bool visible)
    {
        //TODO
    }

    public void Replay()
    {
        DisplayGameOverPanel(false);
        DisplayYouWinPanel(false);
        GameManager.Instance.Replay();
    }


}
