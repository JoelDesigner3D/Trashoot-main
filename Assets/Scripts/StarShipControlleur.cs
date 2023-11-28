using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShipControlleur : MonoBehaviour, iMovable, iShooter
{

    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject bullet;

    private bool readyForShoot = true;

    public void move(float value)
    {
        float moveY = value * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
    }

    public void rotate(float value)
    {
        float rotationZ = -value * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationZ);
    }

    public void Shoot()
    {
        if (readyForShoot) {
            GameObject newBullet = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
            newBullet.transform.rotation = gameObject.transform.rotation;
            //newBullet.transform.localScale = new Vector3(10,10,10) ;

            newBullet.GetComponent<BulletController>().Fire();
            readyForShoot = false;
        }
    }

    void Update()
    {
        // Rotation input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move input
        float verticalInput = Input.GetAxis("Vertical");

        // rotation
        rotate(horizontalInput);

        // Moving
        move(verticalInput);

        //Fire
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        //Or not fire !
        if (Input.GetKeyUp(KeyCode.Space))
        {
            readyForShoot = true;
        }
    }
}
