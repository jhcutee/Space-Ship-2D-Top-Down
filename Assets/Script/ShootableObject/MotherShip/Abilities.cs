using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : Monobehahaha
{
    [Header("Abilities")]
    [SerializeField] private AbilityObjectController abilityObjectController;
    public AbilityObjectController AbilityObjectController => abilityObjectController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSpawnPos();
    }
    protected virtual void LoadSpawnPos()
    {
        if (abilityObjectController != null) return;
        abilityObjectController = transform.parent.GetComponent<AbilityObjectController>();
    }
}
