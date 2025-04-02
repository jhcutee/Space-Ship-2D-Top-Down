using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : Monobehahaha
{
    [Header("ObjectAppearing")]
    [SerializeField] protected bool isAppreaing = true;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObserverApear> observers = new List<IObserverApear>();
    protected override void Start()
    {
        base.Start();
        this.StartObserverOnAppear();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }
    protected abstract void Appearing();

    public virtual void Appear()
    {
        isAppreaing = false;
        appeared = true;
        this.FinishObserverOnAppear();
    }
    public virtual void AddObserver(IObserverApear observer)
    {
        observers.Add(observer);
    }
    protected virtual void StartObserverOnAppear()
    {
        foreach(IObserverApear observer in observers)
        {
            observer.StartObserverOnAppear();
        }
    }
    protected virtual void FinishObserverOnAppear()
    {
        foreach (IObserverApear observer in observers)
        {
            observer.FinishObserverOnAppear();
        }
    }

}
