using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : PlayerAbstract
{

    public virtual void Pick(ItemPickable itemPickable)
    {
        ItemInventory itemInventory = itemPickable.ItemController.ItemInventory;
        if (this.playerController.currentShip.inventory.AddItem(itemInventory))
        {
            itemPickable.Picked();
        }
    }
}
