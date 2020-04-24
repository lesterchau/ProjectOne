using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    public WeaponsType weaponsType;

    public float FireRate;
    public float SpreadAngle;

    public GameObject bulletPrefab;
    public int CostPerBullet;
    public float BulletDamage;
    public float bulletForce;

    protected float nextTimeFire;

    private void OnEnable()
    {
        nextTimeFire = Time.time;
    }

    public void resetTime()
    {
        if (Time.time > nextTimeFire)
            nextTimeFire = Time.time;
    }

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Weapons;
    }

    public virtual void Fire(Vector2 position, Quaternion rotation)
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire += FireRate;
            FireBullet(position, rotation);
        }
    }

    protected void FireBullet(Vector2 position, Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
        bullet.GetComponent<Bullet>().Damage = BulletDamage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
