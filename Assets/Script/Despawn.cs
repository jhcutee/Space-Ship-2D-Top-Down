using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : Monobehahaha
{
    protected virtual void FixedUpdate()
    {
        CheckDead();
    }
    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected virtual void CheckDead()
    {
        if(!CanDead()) return;
        DespawnObject();
    }
    protected abstract bool CanDead();
}
