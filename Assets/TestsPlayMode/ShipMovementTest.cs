using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShipMovementTest
{
    private GameObject ship;
    private StarShipControlleur starShipControlleur;
    private float initialPosition;
    private float finalPosition;
    private float moveSpeed = 5f;

    [SetUp]
    public void Setup()
    {
        //Arrange
        ship = new GameObject();
        Rigidbody2D rigidbody2D = ship.AddComponent<Rigidbody2D>();
        starShipControlleur = ship.AddComponent<StarShipControlleur>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(ship);
    }

    //=========================================================================
    //  Move
    //=========================================================================

    [UnityTest]
    public IEnumerator ShipMovementForwardTest()
    {
        //Arrange
        starShipControlleur.Initialize(moveSpeed);

        //act
        initialPosition = ship.transform.position.y;
        Debug.Log("initial : " + initialPosition);

        starShipControlleur.move(5f);
        yield return new WaitForSeconds(0.2f);

        finalPosition = ship.transform.position.y;
        Debug.Log("final : " + finalPosition);

        //Assert
        Assert.IsTrue(finalPosition < initialPosition);  // vers le haut le y diminue
    }

    //=========================================================================
    //  Rotation
    //=========================================================================

    private Vector3 rotationAngles;

    [UnityTest]
    public IEnumerator ShipMovementRotationRightTest()
    {

        //act
        rotationAngles = ship.transform.rotation.eulerAngles;
        initialPosition = rotationAngles.z;
        Debug.Log("initial : " + initialPosition);

        starShipControlleur.rotate(-100f);
        yield return new WaitForSeconds(0.2f);

        rotationAngles = ship.transform.rotation.eulerAngles;
        finalPosition = rotationAngles.z;
        Debug.Log("final : " + finalPosition);

        //Assert
        Assert.IsTrue(finalPosition < 180); // tourné vers la droite
    }

    [UnityTest]
    public IEnumerator ShipMovementRotationLeftTest()
    {

        //act
        //initialPosition = ship.transform.localEulerAngles.z;
        rotationAngles = ship.transform.rotation.eulerAngles;
        initialPosition = rotationAngles.z;
        Debug.Log("initial : " + initialPosition);

        starShipControlleur.rotate(100f);
        yield return new WaitForSeconds(0.2f);

        rotationAngles = ship.transform.rotation.eulerAngles;
        finalPosition = rotationAngles.z;
        Debug.Log("final : " + finalPosition);

        //Assert
        Assert.IsTrue(finalPosition > 180); // tourné vers la gauche
    }
}
