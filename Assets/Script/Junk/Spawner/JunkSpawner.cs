using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    //public static JunkSpawner Instance { get => instance; }
    public static string Junk1 = "Junk1";

    public static JunkSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogWarning("Only 1 JunkSpawner allow to exits ");
        instance = this;
    }
}
