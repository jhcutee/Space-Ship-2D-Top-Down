using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        ItemSpawn.Instance.Despawn(transform.parent);
    }
    protected override void LoadValue()
    {
        this.distanceLimit = 70f;
    }
}
