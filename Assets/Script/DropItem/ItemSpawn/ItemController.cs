using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Monobehahaha
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadItemDespawn();
        LoadItemProfile();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log("LoaditemDespawn");
    }
    public virtual void SetItemInventory(ItemInventory item)
    {
        this.itemInventory = item.Clone();
    }
    protected virtual void LoadItemProfile()
    {
        if (itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodePaser.FromString(this.transform.name);
        ItemProfile itemProfile =  ItemProfile.GetItemProfileByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        ResetValue();
    }
    protected virtual void ResetValue()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
