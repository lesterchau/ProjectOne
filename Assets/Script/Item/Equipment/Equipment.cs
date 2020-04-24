using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{
    public EquipmentTypes EquapimentType;

    protected new void OnValidate()
    {
        base.OnValidate();
        IsStackable = false;
        ItemType = ItemTypes.Equapiments;
    }

}
