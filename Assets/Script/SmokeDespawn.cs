using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        SmokeSpawner.Instance.Despawn(transform.parent);
    }
}
