using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : Monobehahaha
{
    private Transform model;

    public Transform Model { get => model; }
    private JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get => junkDespawn; }
    public ShootableObject ShootableObject { get => shootableObject;}

    [SerializeField] private ShootableObject shootableObject;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadModel();
        LoadJunkDeSpawn();
        LoadSO();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        //Debug.Log("LoadModel");
    }
    protected virtual void LoadJunkDeSpawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        //Debug.Log("LoadJunkDeSpawn");
    }
    protected virtual void LoadSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + this.transform.name;
        shootableObject = Resources.Load<ShootableObject>(resPath);
    }
}
