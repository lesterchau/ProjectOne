using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string ItemName;
    public string Description;
    public int ItemId;
    public Sprite IconImage;
    public bool IsStackable;
    public ItemTypes ItemType;

    protected virtual void OnValidate()
    {
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
        ItemName = System.IO.Path.GetFileNameWithoutExtension(assetPath);
        Description = "This is a " + ItemName;
    }
}
