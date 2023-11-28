using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{
    public float forwardForce = 100f; // Magnitude de la force vers l'avant

    private Rigidbody2D rb; // Référence au composant Rigidbody

    void Start()
    {
        // Obtenez la référence au composant Rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Assurez-vous que le Rigidbody a une masse non nulle pour que la force ait un effet
        if (rb.mass == 0f)
        {
            Debug.LogWarning("La masse du Rigidbody est nulle. Assurez-vous que la masse est correctement définie.");
        }
    }

    void Update()
    {
        // Exemple : Appliquez la force lorsque la touche "F" est enfoncée
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Appliquez une force vers l'avant au Rigidbody
            rb.AddForce(transform.up * forwardForce);
        }
    }
}
