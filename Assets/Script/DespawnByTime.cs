using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    public float timeDelay = 2f;
    public float timeCount = 0;
    protected override void OnEnable()
    {
        base.OnEnable();
        ResetTime();
    }
    protected virtual void ResetTime()
    {
        timeCount = 0;
    }
    protected override bool CanDead()
    {
        timeCount += Time.fixedDeltaTime;
        if (timeCount > timeDelay) return true;
        return false;
    }
}
