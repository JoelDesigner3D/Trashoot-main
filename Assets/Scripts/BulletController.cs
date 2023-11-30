using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, iExplosive
{

    [SerializeField] private float forceMagnitude = 10f;
    [SerializeField] private ParticleSystem explosion;

    public void Explode()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void Fire()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * forceMagnitude, ForceMode2D.Impulse);
    }

    public void rotate(float value)
    {
        throw new System.NotImplementedException();
    }


    private void FarFarAway() // ... a long time ago in a galaxy 
    {
        Vector3 worldPosition = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            //Debug.Log("Le projectile est en dehors de l'écran!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            collision.gameObject.GetComponent<TrashController>().Explode();
            this.Explode();
        }
    }

    private void Update()
    {
        FarFarAway();
    }

}
