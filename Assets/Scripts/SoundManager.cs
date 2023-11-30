using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

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

    //=================================


    [SerializeField] private AudioSource starShipExplosion;
    [SerializeField] private AudioSource trashExplosion;


    public void playTrashExplosion()
    {
        trashExplosion.Play();
    }


    public void playStarShipExplosion()
    {
        starShipExplosion.Play();
    }


}
