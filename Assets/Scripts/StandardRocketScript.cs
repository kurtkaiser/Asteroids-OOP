using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRocketScript : PlayerScript
{
    // Start is called before the first frame update
    void Start()
    {
        base.turnSpeed *= 2;
    }

    // Overrided method in rocket class - runtime polymorphism
    protected override void FireSpecialWeapon()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("override special weapon");
        }
    }
}
