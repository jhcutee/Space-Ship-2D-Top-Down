using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDmgReceiver : DmgReceiver
{

    [SerializeField]private ShootableObjectController shootableObjectController;

    public ShootableObjectController ShootableObjectController { get => shootableObjectController; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShootableObjectController();
    }
    public override void Reborn()
    {
        if (this.shootableObjectController == null)
        {
            Debug.LogError("❌ JunkController chưa được load!");
            return;
        }

        if (this.shootableObjectController.ShootableObject == null)
        {
            Debug.LogError("❌ JunkController.Info bị null!");
            return;
        }

        this.maxHp = this.shootableObjectController.ShootableObject.hpMax; // Cập nhật lại hpMax
        this.hp = this.maxHp; // Đặt lại máu theo hpMax mới

        Debug.Log($"✅ Reborn thành công! maxHp: {this.maxHp}, hp: {this.hp}");

        base.Reborn();
    }
    protected virtual void LoadShootableObjectController()
    {
        if (shootableObjectController != null) return;
        shootableObjectController = transform.parent.GetComponent<ShootableObjectController>();
        //Debug.Log("LoadJunkController");
    }
    protected override void OnDead()
    {
        //Debug.Log(gameObject.name + " OnDead() thực sự được gọi!");
        GetFXOnDead();
        DropItemOnDead();
        this.shootableObjectController.Despawn.DespawnObject();
    }
    public virtual void DropItemOnDead()
    {
        Vector3 pos = this.transform.position;
        Quaternion rot = this.transform.rotation;
        ItemSpawn.Instance.Drop(this.ShootableObjectController.ShootableObject.dropList, pos, rot);
    }
    protected virtual void GetFXOnDead()
    {
        string fx = GetFXName();
        Transform fxprefab = SmokeSpawner.Instance.Spawm(fx, this.transform.position, this.transform.rotation);
        //Debug.Log("FXFXFX");
        fxprefab.gameObject.SetActive(true);
    }
    protected virtual string GetFXName()
    {
        return SmokeSpawner.Smoke;
    }

}
