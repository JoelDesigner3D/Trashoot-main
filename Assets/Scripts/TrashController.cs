using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour, iExplosive
{

    [SerializeField] private float forceMagnitude = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculez la direction vers le centre de l'écran
        Vector3 centerDirection = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)) - transform.position;

        // Normalisez la direction
        Vector3 normalizedDirection = centerDirection.normalized;

        // Appliquez la force au Rigidbody
        rb.AddForce(normalizedDirection * forceMagnitude, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StarShip"))
        {
            this.Explode();
            Destroy(collision.gameObject);
        }
    }


    public void Explode()
    {
        Destroy(gameObject);
    }
}
