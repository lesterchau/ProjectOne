using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Heads", order = 1)]
public class Head : Equipment
{
    public int EnergyCost;
    public float ViewDistance;

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Heads;
    }
}
