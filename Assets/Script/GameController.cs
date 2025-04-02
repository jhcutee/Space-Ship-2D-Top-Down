using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Monobehahaha
{
    private static GameController instance;

    public static GameController Instance { get => instance; }
    public Camera MainCamera { get => mainCamera;}

    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogWarning("Only 1 GameController allow to exits ");
        instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCamera();
    }
    protected void LoadCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Camera.main;
        //Debug.Log("LoadCamera");
    }
}
