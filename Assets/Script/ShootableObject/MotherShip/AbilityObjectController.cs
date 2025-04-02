using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityObjectController : ShootableObjectController
{
    [Header("AbilityObjectController")]
    [SerializeField] private spawnPos spawnPos;
    public spawnPos SpawnPos => spawnPos;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSpawnPos();
    }
    protected virtual void LoadSpawnPos()
    {
        if (spawnPos != null) return;
        spawnPos = transform.GetComponentInChildren<spawnPos>();
    }
}
