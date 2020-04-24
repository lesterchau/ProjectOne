using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : Equipment
{

    public ModulesType moduleType;

    protected new void OnValidate()
    {
        base.OnValidate();
        EquapimentType = EquipmentTypes.Modules;
    }
}
