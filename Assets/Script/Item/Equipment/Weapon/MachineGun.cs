using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Weapons/MachineGuns", order = 0)]
public class MachineGun : Weapon
{

    public override void Fire(Vector2 position, Quaternion rotation, PlayerStat player)
    {
        rotation *= Quaternion.Euler(Vector3.forward * Random.Range(-SpreadAngle, SpreadAngle));
        base.Fire(position, rotation, player);
    }

    protected new void OnValidate()
    {
        base.OnValidate();
        weaponsType = WeaponsType.MachineGun;
    }

}
