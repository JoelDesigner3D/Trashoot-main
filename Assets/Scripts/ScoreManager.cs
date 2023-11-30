using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }
    //==================================

    private int globalScore = 0;

    [SerializeField] private UIManager uiManager;

    public void OnTrashDestroyed(int score)
    {
        Debug.Log("OnTrashDestroyed triggered");
        AddScore(score);
    }

    public void AddScore(int score)
    {
        globalScore += score;
        uiManager.DisplayScore(globalScore);
    }

}
