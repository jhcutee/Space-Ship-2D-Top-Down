using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : IventoryAbstact
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 8f);
    }
    protected virtual void Test()
    {
        Vector3 dropPos = this.transform.position;
        dropPos.x += 1;
        DropItemIndex(0, dropPos, this.transform.rotation);
    }
    protected virtual void DropItemIndex(int index,Vector3 dropPos, Quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.itemInventories[index];
        ItemSpawn.Instance.Drop(itemInventory, dropPos, dropRot);
        this.inventory.itemInventories.Remove(itemInventory);
    }
}
