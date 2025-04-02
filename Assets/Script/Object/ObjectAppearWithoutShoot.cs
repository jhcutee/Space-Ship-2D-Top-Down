using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearWithoutShoot : ShootableObjectAbstract, IObserverApear
{
    [Header("ObjectAppearWithoutShoot")]
    [SerializeField] private ObjectAppearing objectAppearing;

    public ObjectAppearing ObjectAppearing { get => objectAppearing; }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterObserverEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjectAppearing();
    }
    protected virtual void LoadObjectAppearing()
    {
        if(objectAppearing != null) return;
        objectAppearing = GetComponent<ObjectAppearing>();
    }
    protected virtual void RegisterObserverEvent()
    {
        this.objectAppearing.AddObserver(this);
    }

    public void StartObserverOnAppear()
    {
        this.Controller.EnemyShooting.gameObject.SetActive(false);
    }

    public void FinishObserverOnAppear()
    {
        this.Controller.EnemyShooting.gameObject.SetActive(true);
    }
}
