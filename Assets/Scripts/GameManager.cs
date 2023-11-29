using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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
