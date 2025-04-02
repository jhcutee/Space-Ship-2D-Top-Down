using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDmgReceiver : DmgReceiver
{
    private JunkController junkController;

    public JunkController JunkController { get => junkController; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJunkController();
    }
    public override void Reborn()
    {
        if (this.junkController == null)
        {
            Debug.LogError("❌ JunkController chưa được load!");
            return;
        }

        if (this.junkController.ShootableObject == null)
        {
            Debug.LogError("❌ JunkController.Info bị null!");
            return;
        }

        this.maxHp = this.junkController.ShootableObject.hpMax; // Cập nhật lại hpMax
        this.hp = this.maxHp; // Đặt lại máu theo hpMax mới

        Debug.Log($"✅ Reborn thành công! maxHp: {this.maxHp}, hp: {this.hp}");

        base.Reborn();
    }
    protected virtual void LoadJunkController()
    {
        if (junkController != null) return;
        junkController = transform.parent.GetComponent<JunkController>();
        //Debug.Log("LoadJunkController");
    }
    protected override void OnDead()
    {
        //Debug.Log(gameObject.name + " OnDead() thực sự được gọi!");
        GetFXOnDead();
        DropItemOnDead();
        this.junkController.JunkDespawn.DespawnObject();
    }
    public virtual void DropItemOnDead()
    {
        Vector3 pos = this.transform.position;
        Quaternion rot = this.transform.rotation;
        ItemSpawn.Instance.Drop(this.JunkController.ShootableObject.dropList,pos,rot);
    }
    protected virtual void GetFXOnDead()
    {
        string fx = GetFXName();
        Transform fxprefab = SmokeSpawner.Instance.Spawm(fx,this.transform.position, this.transform.rotation);
        //Debug.Log("FXFXFX");
        fxprefab.gameObject.SetActive(true);
    }
    protected virtual string GetFXName()
    {
        return SmokeSpawner.Smoke;
    }
    
}
