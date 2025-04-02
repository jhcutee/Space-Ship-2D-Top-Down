using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : Monobehahaha
{
    private JunkController junkController;

    public JunkController JunkController { get => junkController; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJunkController();
    }
    protected virtual void LoadJunkController()
    {
        if (junkController != null) return;
        junkController = transform.parent.GetComponent<JunkController>();
        //Debug.Log("LoadJunkController");
    }
}
