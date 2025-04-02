using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(SphereCollider))]
public class BulletImpact : BulletAbstact
{
    [Header("BulletImpact")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected SphereCollider sphereCollider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody>();
        this.rb.isKinematic = true;
        //Debug.Log("LoadRigidbody");
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        //Debug.Log("LoadSphereCollider");
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.transform.parent.name);
        //Debug.Log(BulletController.Shooter.name);
        if (collision.transform.parent.name == BulletController.Shooter.name) return;
        //Debug.Log("Shoot");
        this.BulletController.DmgSender.Send(collision.transform);
    }
   
}
