using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfile")]
public class ItemProfile : ScriptableObject
{
    public ItemCode itemCode = ItemCode.noItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> itemRecipesUpgradeLevel;

    public static ItemProfile GetItemProfileByItemCode(ItemCode itemCode)
    {
        var itemprofiles = Resources.LoadAll<ItemProfile>("ItemProfile");
        foreach(ItemProfile itemProfile in itemprofiles)
        {
            if (itemProfile.itemCode != itemCode) continue;
            return itemProfile;
        }
        return null;
    }
}
