using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

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

        DontDestroyOnLoad(gameObject);
    }

    //--------------------------------------------------------------

    [SerializeField] private UIManager uIManager;

    public void GameOver()
    {
        uIManager.DisplayGameOverPanel(true);
    }


    public void Replay()
    {
        uIManager.DisplayNewGamePanel(true);

        // reset score
        // reset game
    }


    public void Quit()
    {
        Application.Quit();
    }


    private void OnApplicationQuit()
    {
        Debug.Log("Ciao monde cruel, je vais vers la lumière blanche !");
    }


}
