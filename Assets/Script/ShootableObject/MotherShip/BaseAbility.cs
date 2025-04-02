using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : Monobehahaha
{
    [Header("BaseAbility")]
    [SerializeField] protected float timerDelay = 2f;
    [SerializeField] protected float timerCount = 2f;
    [SerializeField] protected bool isReady = false;
    protected virtual void FixedUpdate()
    {
        this.Timming();
    }
    protected virtual void Timming()
    {
        if (isReady) return;
        timerCount += Time.fixedDeltaTime;
        if (this.timerCount < this.timerDelay) return;
        isReady = true;
    }
    protected virtual void Active()
    {
        isReady = false;
        timerCount = 0;
    }
}
