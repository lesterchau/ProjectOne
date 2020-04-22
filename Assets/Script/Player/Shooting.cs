using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    public float bulletForce = 20f;

    public Weapon weapon;

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.resetTime();
        }
        else if (Input.GetButton("Fire1"))
        {
            weapon.Fire(firePoint);
        }
    }

}
