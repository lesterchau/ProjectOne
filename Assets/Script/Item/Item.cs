using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string ItemName;
    public string Description;
    public int ItemId;
    public Sprite IconImage;
    public bool HasQuantity;
    [DrawIf("HasQuantity", true, ComparisonType.Equals)]
    public int Quantity;
    public ItemTypes ItemType;
}
