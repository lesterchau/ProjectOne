using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Weapons/MachineGuns")]
public class MachineGun : Weapon
{

    public override void Fire(Transform firePoint)
    {
        Vector2 newDir = firePoint.up;
        base.Fire(firePoint);
    }

}
