using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour, ItemHealth
{
    private int health = 100;
    // Static to be used by all class members
    public static int astroidCount = 50;
    private float speed { get; set; }
    private GameManager gameManager;

    void Start()
    {
        speed = 0.25f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        Vector3 position = this.transform.position;
        position.x += speed;
        this.transform.position = position;
    }

    // Accessed directly from constructor, not from object instance
    public static void AsteroidDestroyed()
    {
        astroidCount--;
    }

    public void TakeDamage(int amount)
    {
        health -= amount * Random.Range(0, 2);
    }

    // Overloading - happens at compile time
    public void TakeDamage(float fltAmount)
    {
        TakeDamage((int)fltAmount);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = -speed;
        GameObject brokeAsteroid = gameManager.GetAsteroidGroup();
        Instantiate(brokeAsteroid, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void DestroyAsteroid()
    {
        Destroy(gameObject);        
    }
}
