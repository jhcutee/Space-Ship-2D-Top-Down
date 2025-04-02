using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : Monobehahaha
{
    [Header("PlayerAbstract")]
    [SerializeField] protected PlayerController playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (playerController != null) return;
        playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log("LoadPlayerController");
    }
}
