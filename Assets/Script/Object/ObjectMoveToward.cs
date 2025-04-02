using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveToward : ShipMovement
{
    [Header("Move Foward")]
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        GetMovePos();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMoveTarget();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveToward");
    }
    protected virtual void GetMovePos()
    {
        this.targetPos = this.moveTarget.position;
        this.targetPos.z = 0;
    }
}
