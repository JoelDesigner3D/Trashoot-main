using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
/*
public class IntEvent : UnityEvent<int> {

}
*/
public class BoolEvent : UnityEvent<bool>
{

}


public class TimeManager : MonoBehaviour
{

    public static TimeManager Instance;

    public IntEvent OnNewScore;

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

    [SerializeField] private float gameDuration = 30f;

    public BoolEvent OnTimeElapsed;


    private void Start()
    {
        StartTimer();
    }


    public void StartTimer()
    {
        StartCoroutine(Wait(gameDuration));
    }


    public void StopTimer()
    {
        OnTimeElapsed.Invoke(true);
    }


    IEnumerator Wait(float gameDuration)
    {
        yield return new WaitForSeconds(gameDuration);
        StopTimer();
    }


    public void CloseTimer()
    {
        StopCoroutine(Wait(gameDuration));
    }


    public void TimeElapsed()
    {
        GameManager.Instance.YouWin();
    }


}
