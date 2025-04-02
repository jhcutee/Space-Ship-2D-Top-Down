using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbstract : Monobehahaha
{
    [SerializeField] protected ItemController itemController;
    public ItemController ItemController => itemController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadItemController();
    }
    protected virtual void LoadItemController()
    {
        if (itemController != null) return;
        itemController = transform.GetComponentInParent<ItemController>();
        //Debug.Log("LoadItemController");
    }
}
