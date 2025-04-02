using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : Spawner
{
    private static ItemSpawn instance;
    public static ItemSpawn Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogWarning("Only 1 ItemDropSpawner allow to exits ");
        instance = this;
    }
    public virtual void Drop(List<DropList> dropList, Vector3 pos, Quaternion rot)
    {
        //LAY RA 1 
        if (dropList.Count < 1) return;
        ItemCode itemCode = dropList[0].itemProfile.itemCode;
        Transform itemDrop = this.Spawm(itemCode.ToString(), pos, rot);
        if (itemDrop == null)
        {
            Debug.Log("Null");
            return;
        }
        itemDrop.gameObject.SetActive(true);
    }
    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        //LAY RA 1 
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawm(itemCode.ToString(), pos, rot);
        if (itemDrop == null)
        {
            Debug.Log("Null");
            return null;
        }
        itemDrop.gameObject.SetActive(true);
        ItemController itemController = itemDrop.GetComponent<ItemController>();
        itemController.SetItemInventory(itemInventory);
        return itemDrop;
    }
}
