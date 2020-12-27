using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, CanShoot, ItemHealth
{
    public float health { get; set; }
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    protected float turnSpeed = 0.5f;
    public Vector3 vec;

    private void Start()
    {
        health = 25;
        vec = transform.localEulerAngles;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -turnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, turnSpeed, 0);
        }            
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void FireWeapon(UnityEngine.Vector3 hitPosition)
    {

    }

    // Example of overloading, same class name, different parameters
    private void EarnBonus(int bonus)
    {
        health += bonus;
    }

    // Overloading, now using a float
    private void EarnBonus(float bonus)
    {
        health += bonus;
    }

    // Overrided method in rocket class - runtime polymorphism
    protected virtual void FireSpecialWeapon()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("special weapon");
        }
    }
}
