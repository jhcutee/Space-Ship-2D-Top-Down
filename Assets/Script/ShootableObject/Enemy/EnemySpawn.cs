using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner
{
    private static EnemySpawn instance;
    public static EnemySpawn Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogWarning("Only 1 EnemySpawn allow to exits ");
        instance = this;
    }
}
