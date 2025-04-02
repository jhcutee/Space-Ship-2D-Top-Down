using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent (typeof(Rigidbody))]
public class ItemLooter : IventoryAbstact
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rb;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadRigibody();
        LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.3f;
        //Debug.Log("LoadSphereCollider");
    }
    protected virtual void LoadRigibody()
    {
        if(rb != null) return;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        // Debug.Log("LoadRigibody");
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemPickable itemPickable = other.GetComponent<ItemPickable>();
        if(itemPickable == null ) return;
        
        ItemInventory itemInventory = itemPickable.ItemController.ItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickable.Picked();
        }
    }
}
