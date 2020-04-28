using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons", menuName = "Items/Equipments/Cores", order = 3)]
public class Core : Equipment
{
    public float MaximumEnergy;
    public float RegenerateRate;

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Cores;
        Description += "\nMaximum Energy: " + MaximumEnergy +
                       "\nRegenerate Rate: " + RegenerateRate;
    }
}
