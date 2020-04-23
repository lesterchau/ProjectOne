using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{
    public EquipmentTypes EquapimentType;

    protected void OnValidate()
    {
        HasQuantity = false;
        Quantity = -1;
        ItemType = ItemTypes.Equapiments;
    }

}
