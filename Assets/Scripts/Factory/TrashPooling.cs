using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPooling : Pool

{
    [SerializeField] TrashGenerator trashGenerator;

    private List<GameObject> trashsReferences;

    private void Start()
    {
        trashsReferences = new List<GameObject>();
    }



    public override GameObject Get(Vector2 position)
    {
        
        // Vérifier si une instance est disponible
        
        foreach (GameObject go in trashsReferences)
        {
            //if (!go.activeInHierarchy)
            if (!go.activeSelf) 
            {
                go.SetActive(true);
                go.transform.position = position;
                go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                return go;
            }
        }
        

        // Si aucune n'est disponible, on doit en générer une nouvelle

        GameObject newTrash = trashGenerator.Generate(position, Quaternion.identity);
        trashsReferences.Add(newTrash);

        
        return newTrash;
       

    }



    public override void Release(GameObject element)
    {
        element.gameObject.SetActive(false);
    }
}