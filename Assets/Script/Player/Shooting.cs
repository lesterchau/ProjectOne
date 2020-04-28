using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    public Weapon[] weapons = new Weapon[2];

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
            return;

        PlayerStat stat = GetComponent<PlayerStat>();

        if (Input.GetButtonDown("Fire1"))
        {
            weapons[0].ResetTime();
        }
        else if (Input.GetButton("Fire1"))
        {
            weapons[0].Fire(firePoint.position, firePoint.rotation, stat);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            weapons[1].ResetTime();
        }
        else if (Input.GetButton("Fire2"))
        {
            weapons[1].Fire(firePoint.position, firePoint.rotation, stat);
        }
    }

    public void GetWeapon(Weapon a, Weapon b)
    {
        weapons[0] = a;
        weapons[1] = b;
    }

    private void OnValidate()
    {
        if (weapons.Length == 0)
            weapons = new Weapon[2];
        else if (weapons.Length != 2)
        {
            Weapon[] newWeapon = new Weapon[2];
            if (weapons.Length > 2)
                for (int i = 0; i < 2; i++)
                    newWeapon[i] = weapons[i];
            else if (weapons.Length < 2)
                for (int i = 0; i < weapons.Length; i++)
                    newWeapon[i] = weapons[i];
            weapons = newWeapon;
        }
    }

}
