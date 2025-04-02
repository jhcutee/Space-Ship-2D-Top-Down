using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : Monobehahaha
{
    private static DropManager instance;
    public static DropManager Instance { get => instance; }
    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 DropManager allow to exits ");
        instance = this;
    }
}
