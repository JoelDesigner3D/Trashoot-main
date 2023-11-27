using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, iMovable
{

    [SerializeField] private float moveSpeed = 100f;

    private float viewportWidth;
    private float viewportHeight;

    private Vector2 forceDirection = Vector2.right;


    public void Shoot(GameObject starShip)
    {
        this.move(1);
    }


    public void move(float value)
    {
        float moveY = value * moveSpeed * Time.deltaTime;

        float forceX = gameObject.transform.rotation.x * moveSpeed;
        float forceY = gameObject.transform.rotation.y * moveSpeed;

       // Vector3 forceDirection = this.transform.position - transform.position;

        Vector2 forceVector = forceDirection.normalized * moveSpeed;

        this.GetComponent<Rigidbody2D>().AddForce(forceVector);

    }

    public void rotate(float value)
    {
        throw new System.NotImplementedException();
    }


    private void FarFarAway()
    {
        if (gameObject.transform.position.x > viewportWidth || gameObject.transform.position.y > viewportHeight)
        {
            Destroy(gameObject);
        }
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
