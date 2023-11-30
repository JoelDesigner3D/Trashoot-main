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


    public void OnTimeElapsed()
    {
        YouWin();
    }

    public void WaitForGameOver() { 
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);

        GameOver();
    }

    public void GameOver()
    {
        uIManager.DisplayGameOverPanel(true);
    }


    public void YouWin()
    {
        uIManager.DisplayYouWinPanel(true);
    }


    public void Replay()
    {
        //uIManager.DisplayNewGamePanel(true);

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

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
