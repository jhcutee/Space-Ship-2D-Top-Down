using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting : Monobehahaha
{
    //[SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected float timeDelay = 1f;
    [SerializeField] protected float timeCount = 0;
   
    void FixedUpdate()
    {
        HandleShooting();
    }
    protected virtual void HandleShooting()
    {
        if (!checkShooting()) return;
        timeCount += Time.fixedDeltaTime;
        if (timeCount < timeDelay) return;
        timeCount = 0;
        Vector3 pos = this.transform.parent.position;
        Quaternion rotation = this.transform.parent.rotation;
        Transform temp = BulletSpawner.Instance.Spawm(BulletSpawner.bulletLevel1, pos, rotation);
        temp.gameObject.SetActive(true);
        BulletController bulletController = temp.GetComponent<BulletController>();
        bulletController.SetShooter(this.transform.parent);
        //Debug.Log("Shooting");
    }
    protected abstract bool checkShooting();
}
