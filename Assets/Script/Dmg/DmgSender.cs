using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSender : Monobehahaha
{
    [SerializeField] protected int dmg = 1;
    public virtual void Send(Transform obj)
    {
        DmgReceiver dmgReceiver = obj.GetComponentInChildren<DmgReceiver>();
        if (dmgReceiver == null) return;
        this.Send(dmgReceiver);
        this.GetImpactFX();
    }
    public virtual void Send(DmgReceiver dmgReceiver)
    {
        dmgReceiver.Deduct(dmg);
    }
    protected virtual void GetImpactFX()
    {
        string fxname = GetFX();
        Quaternion rot = Quaternion.Euler(0, 0, -90);
        Transform fx = SmokeSpawner.Instance.Spawm(fxname, this.transform.parent.position, this.transform.parent.rotation * rot);
        fx.gameObject.SetActive(true);
    }
    protected virtual string GetFX()
    {
        return SmokeSpawner.Impact;
    }
}
