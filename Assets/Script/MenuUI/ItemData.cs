[System.Serializable]
public struct ItemData
{
    public Item item;
    public int Quantity;

    public ItemData(Item _item, int _quantity)
    {
        item = _item;
        Quantity = _quantity;
    }

    public void AddQuantity(int num)
    {
        Quantity += num;
    }
}