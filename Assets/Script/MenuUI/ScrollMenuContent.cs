using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenuContent : MonoBehaviour
{
    public GameObject Button;
    public EquipButton EquipButton;
    public Image image;
    public Text text;

    private void Start()
    {
        ChangeTarget(3);
        ChangeSlot(0);
    }

    public void ChangeTarget(int newTarget)
    {
        Spawn((EquipmentTypes)newTarget);
    }

    public void ChangeSlot(int slot)
    {
        EquipButton.Slot = (EquipmentSlot)slot;
    }

    void Spawn(EquipmentTypes target)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        List<ItemData> items = GetComponentInParent<EquipmentMenu>().Items;
        bool selected = false;
        for (int i = 0; i < items.Count; i++)
        {
            ItemData item = items[i];
            if (item.item.ItemType == ItemTypes.Equapiments)
                if (((Equipment)item.item).EquapimentType == target)
                {
                    GameObject newButton = Instantiate(Button, transform);
                    SelectScRollButton select = newButton.GetComponent<SelectScRollButton>();
                    select.num = i;
                    select.GetComponent<Image>().overrideSprite = item.item.IconImage;
                    select.item = item.item;
                    select.equipButton = EquipButton;
                    select.image = image;
                    select.text = text;
                    if (!selected)
                        select.PassNum();
                }
        }
    }
}
