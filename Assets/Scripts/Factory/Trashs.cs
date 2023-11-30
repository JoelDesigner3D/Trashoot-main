using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashs : MonoBehaviour
{
    [SerializeField] private Pool trashPooling;
    //[SerializeField] private float yThreshold = -6;

    private List<GameObject> trashs;
    private List<GameObject> toRemove;

    private void Start()
    {
        trashs = new List<GameObject>();
        toRemove = new List<GameObject>();
    }

    public void Add(GameObject t)
    {
        trashs.Add(t);
    }

    void FixedUpdate()
    {
        toRemove.Clear();

        /*

        foreach (GameObject t in trashs)
        {
            if (t.transform.position.y < yThreshold)
            {
                //Destroy(t.gameObject);
                trashPooling.Release(t);
                toRemove.Add(t);
            }
        }
        */

        if (toRemove.Count > 0)
        {
            trashs.RemoveAll(t => toRemove.Contains(t));
        }
    }
}
