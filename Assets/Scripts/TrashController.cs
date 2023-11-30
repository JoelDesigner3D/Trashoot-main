using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{

}

public class TrashController : MonoBehaviour, iExplosive
{

    [SerializeField] private float forceMagnitude = 1f;

    [SerializeField] private ParticleSystem explosionParticles;
    //[SerializeField] private AudioSource explosionSound;

    public IntEvent OnTrashDestroyed;

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
            collision.gameObject.GetComponent<StarShipControlleur>().Explode();
            this.Explode();
        }
    }


    public void Explode()
    {
        ScoreManager.Instance.AddScore(1);
        //OnTrashDestroyed.Invoke(1);

        ParticleSystem newExplosion = Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity);

        SoundManager.Instance.playTrashExplosion();

        newExplosion.Play();

        gameObject.SetActive(false);
        //Destroy(gameObject, 2); 
    }
}
