using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickable : ItemAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    protected static ItemCode String2Enum(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e)
        {
            Debug.Log(e.ToString());
            return ItemCode.noItem;

        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.2f;
        Debug.Log("LoadSphereCollider");
    }
 
    public virtual ItemCode GetItemCodeByName()
    {
        return ItemPickable.String2Enum(this.transform.parent.name);
    }
    
    public virtual void Picked()
    {
        this.itemController.ItemDespawn.DespawnObject();
    }
    private void OnMouseDown()
    {
        //Debug.Log(transform.parent.name);
        PlayerController.Instance.playerPickupItem.Pick(this);  
    }
}
