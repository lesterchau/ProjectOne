using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButton : MonoBehaviour
{
    public int Num;
    public EquipmentSlot Slot;
    public EquipmentMenu Menu;

    public void Equip()
    {
        Menu.Equip(Num, Slot);
    }
}
