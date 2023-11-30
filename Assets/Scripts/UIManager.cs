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

    private int globalScrore = 0;

    public void OnTrashDestroyed(int score)
    {
        Debug.Log("OnTrashDestroyed triggered");
        DisplayScore(score);
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
        globalScrore += score;
        scoreField.text = "Score : " + globalScrore;
            Debug.Log("Score : "+ globalScrore);
    }

    public void Replay()
    {
        DisplayGameOverPanel(false);
        DisplayYouWinPanel(false);
        GameManager.Instance.Replay();
    }


}
