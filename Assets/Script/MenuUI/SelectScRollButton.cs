using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScRollButton : MonoBehaviour
{
    public int num;
    public Item item;
    public EquipButton equipButton;
    public Image image;
    public Text text;

    public void PassNum()
    {
        equipButton.Num = num;
        image.sprite = item.IconImage;
        text.text = item.Description;
    }
}
