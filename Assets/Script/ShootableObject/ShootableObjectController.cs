using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectController : Monobehahaha
{
    [SerializeField] private Transform model;

    public Transform Model { get => model; }
    [SerializeField] private Despawn despawn;

    public Despawn Despawn { get => despawn; }
    public ShootableObject ShootableObject { get => shootableObject; }

    [SerializeField] private ShootableObject shootableObject;
    public EnemyShooting EnemyShooting { get => enemyShooting; }

    [SerializeField] private EnemyShooting enemyShooting;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadModel();
        LoadDespawn();
        LoadSO();
        LoadEnemyShooting();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        //Debug.Log("LoadModel");
    }
    protected virtual void LoadEnemyShooting()
    {
        if (enemyShooting != null) return;
        enemyShooting = transform.GetComponentInChildren<EnemyShooting>();
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<Despawn>();
        //Debug.Log("LoadJunkDeSpawn");
    }
    protected virtual void LoadSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/"+ this.GetTypeToString()+ "/" + this.transform.name;
        shootableObject = Resources.Load<ShootableObject>(resPath);
    }
    protected abstract string GetTypeToString();
}
