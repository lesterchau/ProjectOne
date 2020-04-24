using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Bodys", order = 2)]
public class Body : Equipment
{
    public int EnergyCost;
    public float HitPoint;
    public float Defense;

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Bodys;
    }
}
