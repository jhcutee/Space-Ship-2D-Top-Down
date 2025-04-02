using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : Spawner
{
    private static SmokeSpawner instance;
    //public static JunkSpawner Instance { get => instance; }
    public static string Smoke = "Smoke";
    public static string Impact = "Impact";

    public static SmokeSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogWarning("Only 1 SmokeSpawner allow to exits ");
        instance = this;
    }
}
