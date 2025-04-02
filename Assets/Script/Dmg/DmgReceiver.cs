using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public abstract class DmgReceiver : Monobehahaha
{
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int maxHp;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected SphereCollider SphereCollider;
    // Start is called before the first frame update
    protected override void LoadValue()
    {
        base.LoadValue();
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSphereCollider();
    }

    // Update is called once per frame
    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        isDead = false;
    }
    public virtual void Add(int add)
    {
        if (isDead) return;
        this.hp += add;
        if(this.hp > this.maxHp) this.hp = this.maxHp;
    }
    protected virtual void LoadSphereCollider()
    {
        if (SphereCollider != null) return;
        SphereCollider = transform.GetComponent<SphereCollider>();
        this.SphereCollider.isTrigger = true;
        this.SphereCollider.radius = 0.4f;
        //Debug.Log("LoadSphereCollider");
    }
    public virtual void Deduct(int deduct)
    {
        if(isDead) return;
        this.hp -= deduct;
        if(this.hp <0) this.hp = 0;
        CheckDead();
        //Debug.Log("Dead!!!");
        //Debug.Log(this.hp);
    }
    public virtual bool IsDead()
    {
        return this.hp == 0;
    }
    public virtual void CheckDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        OnDead();
    }
    protected abstract void OnDead();
}
