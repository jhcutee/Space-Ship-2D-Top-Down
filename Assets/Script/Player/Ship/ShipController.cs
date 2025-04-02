using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : Monobehahaha
{
    [SerializeField] public Inventory inventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = GetComponentInChildren<Inventory>();
        Debug.Log("LoadInventory");
    }
}
