using System;
using System.Collections.Generic;
using static UnityEditor.Progress;
[Serializable]
public class ItemInventory
{
    public ItemProfile itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;
    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory();
        {
            item.itemProfile = this.itemProfile;
            item.itemCount = this.itemCount;
            item.upgradeLevel = this.upgradeLevel;
            item.itemProfile.defaultMaxStack = this.itemProfile.defaultMaxStack;
        }
        return item;
    }
}
