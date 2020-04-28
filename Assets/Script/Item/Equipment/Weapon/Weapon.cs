using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    public WeaponsType weaponsType;

    public float FireRate;
    public float SpreadAngle;

    public GameObject bulletPrefab;
    public float CostPerBullet;
    public float BulletDamage;
    public float bulletForce;

    protected float nextTimeFire;

    private void OnEnable()
    {
        nextTimeFire = Time.time;
    }

    public void ResetTime()
    {
        if (Time.time > nextTimeFire)
            nextTimeFire = Time.time;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Weapons;
        Description += "\nCost: " + CostPerBullet +
                       "\nDamage: " + BulletDamage +
                       "\nFire Rate: " + FireRate +
                       "\nBullet Speed: " + bulletForce;
    }

    public virtual void Fire(Vector2 position, Quaternion rotation, PlayerStat player)
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire += FireRate;
            FireBullet(position, rotation);
            player.currEnergy -= CostPerBullet;
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
