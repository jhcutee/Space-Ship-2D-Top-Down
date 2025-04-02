using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MapSetTarget();
    }
    protected virtual void MapSetTarget()
    {
        if (target != null) return;
        this.target = PlayerController.Instance.currentShip.transform;
        this.SetTarget(target);
    }
}
