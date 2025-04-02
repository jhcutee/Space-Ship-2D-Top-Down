using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmgSender : DmgSender
{
    private BulletController bulletController;

    public BulletController BulletController { get => bulletController; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBullerController();
    }
    protected virtual void LoadBullerController()
    {
        if (bulletController != null) return;
        bulletController = transform.parent.GetComponent<BulletController>();
        if(bulletController == null) { Debug.LogError("CantLoadBulletController"); }

        //Debug.Log("LoadBullerController");
    }
    public override void Send(DmgReceiver dmgReceiver)
    {
        base.Send(dmgReceiver);
        this.DestroyBullet();
    }
    public virtual void DestroyBullet()
    {
        this.bulletController.BulletDespawn.DespawnObject();
    }
}
