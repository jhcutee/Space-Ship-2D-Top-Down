using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectAbstract : Monobehahaha
{
    [Header("ShootableObjectAbstract")]
    [SerializeField] protected ShootableObjectController controller;
    public ShootableObjectController Controller => controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }
    protected virtual void LoadController()
    {
        if (controller != null) return;
        controller = transform.parent.GetComponent<ShootableObjectController>();
    }
}
