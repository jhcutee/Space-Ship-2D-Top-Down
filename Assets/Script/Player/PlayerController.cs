using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Monobehahaha
{
    [SerializeField] private static PlayerController instance;

    public static PlayerController Instance { get => instance; }

    [SerializeField] public ShipController currentShip;
    [SerializeField] public PlayerPickupItem playerPickupItem;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShip();
        this.LoadPlayerPickupItem();    
    }
    protected virtual void LoadShip()
    {
        if (currentShip != null) return;
        currentShip = FindAnyObjectByType<ShipController>();
        Debug.Log("LoadShip");
    }
    protected virtual void LoadPlayerPickupItem() {
        if(playerPickupItem != null) return;
        playerPickupItem = transform.GetComponentInChildren<PlayerPickupItem>();
        Debug.Log("LoadItemPickable");
    }
}
