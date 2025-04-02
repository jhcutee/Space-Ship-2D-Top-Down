using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Monobehahaha
{
    private DmgSender dmgSender;

    public DmgSender DmgSender{ get => dmgSender; }
    private BulletDespawn bulletDespawn;

    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    private Transform shooter;

    public Transform Shooter => shooter;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDmgSender();
        LoadBulletDespawn();
    }
    protected virtual void LoadDmgSender()
    {
        if (dmgSender != null) return;
        dmgSender = transform.GetComponentInChildren<DmgSender>();
        //Debug.Log("LoadDmgSender");
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        //Debug.Log("LoadBulletDespawn");
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
