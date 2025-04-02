using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstact : Monobehahaha
{
    [Header("BulletAbstact")]
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
        //Debug.Log("LoadBullerController");
    }
}
