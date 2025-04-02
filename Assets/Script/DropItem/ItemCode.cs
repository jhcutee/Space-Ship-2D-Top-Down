
using System;

public enum ItemCode
{
    noItem = 0,
    Iron = 1,
    Diamond = 2,
    Sword = 3,
}

public class ItemCodePaser
{
    public static ItemCode FromString(string nameItem)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), nameItem);
        }
        catch
        {
            //Debug.Log(e.ToString());
            return ItemCode.noItem;

        }
    }
}
