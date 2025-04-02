using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryAbstact : Monobehahaha
{
    [SerializeField] protected Inventory inventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = FindAnyObjectByType<Inventory>();
    }
}
