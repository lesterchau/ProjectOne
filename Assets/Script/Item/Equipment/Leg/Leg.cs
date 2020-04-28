using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Legs", order = 4)]
public class Leg : Equipment
{
    public int EnergyCost;
    public float EnergyCostPerSecond;
    public float speed;
    public bool isHover;

    protected override void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Legs;
        Description += "\nCost: " + EnergyCost +
                       "\nSpeed: " + speed +
                       "\nMoving Cost: " + EnergyCostPerSecond;
    }
}
