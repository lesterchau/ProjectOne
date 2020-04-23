using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{

    public float FireRate;
    public float SpreadAngle;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private float nextTimeFire;

    private void OnEnable()
    {
        resetTime();
    }

    public void resetTime()
    {
        nextTimeFire = Time.time;
    }

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Weapons;
    }

    public virtual void Fire(Transform firePoint)
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire += FireRate;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
