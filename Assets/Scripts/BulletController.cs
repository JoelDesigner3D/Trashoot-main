using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float forceMagnitude = 10f;


    private float viewportWidth;
    private float viewportHeight;


    public void Fire()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * forceMagnitude, ForceMode2D.Impulse);
    }

    public void rotate(float value)
    {
        throw new System.NotImplementedException();
    }


    private void FarFarAway()
    {
        Vector3 worldPosition = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Debug.Log("Le projectile est en dehors de l'écran!");
            Destroy(gameObject);
        }

        /*
        if (gameObject.transform.position.x > viewportWidth || gameObject.transform.position.y > viewportHeight)
        {
            
        }
        */
    }


    void Start()
    {
        Camera mainCamera = Camera.main;
        viewportWidth = mainCamera.rect.width;
        viewportHeight = mainCamera.rect.height;
    }


    private void Update()
    {
        FarFarAway();
    }

}
