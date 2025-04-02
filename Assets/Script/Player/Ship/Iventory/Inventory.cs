using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : Monobehahaha
{
    [SerializeField] public int maxSlot = 70;
    [SerializeField] public List<ItemInventory> itemInventories;

    protected override void Start()
    {
        base.Start();

        this.AddItem(ItemCode.Sword, 3);
        this.AddItem(ItemCode.Iron, 18);
        this.AddItem(ItemCode.Diamond,6);
    }
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        ItemProfile itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        int addCount = itemInventory.itemCount;
        ItemType itemType = itemProfile.itemType;

        if(itemType == ItemType.Equipment) return this.AddEquiqment(itemInventory);

        return AddItem(itemCode,addCount);
    }
    public virtual bool AddEquiqment(ItemInventory itemPicked)
    {
        if (IsFullInventory()) return false;

        ItemInventory item = itemPicked.Clone();

        this.itemInventories.Add(item);
        return true;
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfile ItemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for(int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if(itemExist == null)
            {
                if (IsFullInventory()) return false;
                itemExist = this.CreateEmptyItem(ItemProfile);
                this.itemInventories.Add(itemExist);
            }
            newCount  = itemExist.itemCount + addRemain;
            itemMaxStack = GetMaxStack(itemExist);
            if(newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }
    protected virtual bool IsFullInventory()
    {
        if (this.itemInventories.Count >= this.maxSlot) return true;
        return false;
    }
    protected virtual ItemProfile GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll<ItemProfile>("ItemProfile");
        foreach(ItemProfile profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach(ItemInventory item in this.itemInventories)
        {
            if(item.itemProfile.itemCode != itemCode) continue ;
            if (this.IsFullStack(item)) continue;
            return item;
        }
        return null;
    }
    protected virtual bool IsFullStack(ItemInventory item)
    {
        if(item == null) return false;

        item.maxStack = GetMaxStack(item);
        return item.maxStack <= item.itemCount;
    }
    protected virtual int GetMaxStack(ItemInventory item)
    {
        if (item == null) return 0;
        return item.maxStack;

    }
    public virtual bool CheckItem(ItemCode itemCode, int numCountCheck)
    {
        int totolCount = this.ItemTotalCount(itemCode);
        //Debug.Log(itemCode.ToString()+ ": " +totolCount);
        return totolCount >= numCountCheck;
    }
    protected virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach(ItemInventory inventory in this.itemInventories)
        {
            if(inventory.itemProfile.itemCode != itemCode) continue;
            totalCount += inventory.itemCount; // cong tat ca vao bo qua nhung cai khong trung itemcode
        }
        return totalCount;
    }
    protected virtual ItemInventory CreateEmptyItem(ItemProfile profile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = profile,
            maxStack = profile.defaultMaxStack
        };
        //this.itemInventories.Add(itemInventory);
        return itemInventory;
    }
    public virtual void DeductItem(ItemCode itemCode, int totalDeduct)
    {
        ItemInventory itemInventory;
        int deduct;
        for(int i = this.itemInventories.Count - 1; i >= 0; i--)
        {
            if (totalDeduct <= 0) return;
            itemInventory = this.itemInventories[i];
            if(itemInventory.itemProfile.itemCode != itemCode) continue;
            if(totalDeduct > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                totalDeduct -= itemInventory.itemCount;
            }
            else
            {
                deduct = totalDeduct;
                totalDeduct = 0;
            }
            itemInventory.itemCount -= deduct;
        }

        ClearEmptySlot();
    }
    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for(int i = 0; i < this.itemInventories.Count; i++)
        {
            itemInventory = this.itemInventories[i];
            if(itemInventory.itemCount == 0) itemInventories.RemoveAt(i);
        }
    }
}
