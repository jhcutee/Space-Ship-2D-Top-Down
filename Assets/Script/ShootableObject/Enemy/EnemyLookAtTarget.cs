using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtTarget : ObjectLookAtTarget
{
    [Header("EnemyMovement")]
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        GetTargetPos();
        base.FixedUpdate();
    }
    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void GetTargetPos()
    {
        this.targetPos = this.target.position;
        this.targetPos.z = 0;
    }
}
