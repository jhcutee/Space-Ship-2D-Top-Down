using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
    protected override void LoadValue()
    {
        this.distanceLimit = 34f;
    }
}
