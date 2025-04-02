using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawn.Instance.Despawn(transform.parent);
    }
    protected override void LoadValue()
    {
        this.distanceLimit = 34f;
    }
}
