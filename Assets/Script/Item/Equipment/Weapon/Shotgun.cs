using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Weapons/Shotguns", order = 1)]
public class Shotgun : Weapon
{

    public int TotalBullets;

    public override void Fire(Vector2 position, Quaternion rotation)
    {
        if (Time.time > nextTimeFire)
        {
            nextTimeFire += FireRate;
            Quaternion[] rotations = calculateRotation(rotation);
            foreach (Quaternion rotate in rotations)
            {
                FireBullet(position, rotate);
            }
        }
    }

    private Quaternion[] calculateRotation(Quaternion rotation)
    {
        Quaternion[] result = new Quaternion[TotalBullets];
        int half = TotalBullets / 2;

        if (TotalBullets % 2 != 0)
        {
            result[half] = rotation;

            for (int i = 0; i < half; i++)
            {
                result[i] = rotation * Quaternion.Euler(Vector3.back * SpreadAngle * (half - i));
                result[result.Length - i - 1] = rotation * Quaternion.Euler(Vector3.forward * SpreadAngle * (half - i));
            }
        }
        else
        {
            int halfMinusOne = half - 1;
            float halfSpreadAngle = SpreadAngle / 2.0f;
            result[half] = rotation * Quaternion.Euler(Vector3.back * halfSpreadAngle);
            result[halfMinusOne] = rotation * Quaternion.Euler(Vector3.forward * halfSpreadAngle);
            for (int i = 0; i < halfMinusOne; i++)
            {
                result[i] = result[half] * Quaternion.Euler(Vector3.back * SpreadAngle * (halfMinusOne - i));
                result[result.Length - i - 1] = result[halfMinusOne] * Quaternion.Euler(Vector3.forward * SpreadAngle * (halfMinusOne - i));
            }

        }
        return result;
    }

    protected new void OnValidate()
    {
        base.OnValidate();
        weaponsType = WeaponsType.ShotGun;
    }

}
