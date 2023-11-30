using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] TrashPooling trashPooling;
    [SerializeField] TrashGenerator trashGenerator;
    [SerializeField] List<GameObject> trashPrefabs;

    
    /*
    void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int RandomNumber = Random.Range(0, spawnPoints.Count);

            //trashGenerator.Generate(spawnPoints[RandomNumber].transform.position, Quaternion.identity);
            trashPooling.Get(spawnPoints[RandomNumber].transform.position);

        }
    }
    */

    
    
    void Update()
    {


        while (spawnPoints.Count > GameObject.FindGameObjectsWithTag("Trash").Length)
        {
            int RandomNumber = Random.Range(0, spawnPoints.Count);

            Instantiate(trashPrefabs[Random.Range(0, trashPrefabs.Count)],
                spawnPoints[RandomNumber].transform.position,
                spawnPoints[RandomNumber].transform.rotation);
        }

    }
    
}
