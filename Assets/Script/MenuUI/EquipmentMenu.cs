using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : MonoBehaviour
{
    public List<ItemData> Items = new List<ItemData>();
    public int[] SelectedEquipment = new int[System.Enum.GetValues(typeof(EquipmentSlot)).Length];
    public void AddItem(ItemData _item)
    {
        if (_item.item.IsStackable)
        {
            int index;
            if ((index = SearchTarget(_item.item)) != -1)
                Items[index].AddQuantity(_item.Quantity);
            else
                Items.Add(_item);
        }
        else
            Items.Add(_item);
    }

    private int SearchTarget(Item target)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Equals(target))
                return i;
        }
        return -1;
    }

    void OnEnable()
    {
        if (SelectedEquipment.Length != System.Enum.GetValues(typeof(EquipmentSlot)).Length)
            SelectedEquipment = new int[System.Enum.GetValues(typeof(EquipmentSlot)).Length];
    }

    void OnValidate()
    {
        if (SelectedEquipment.Length != System.Enum.GetValues(typeof(EquipmentSlot)).Length)
            SelectedEquipment = new int[System.Enum.GetValues(typeof(EquipmentSlot)).Length];
    }

}
