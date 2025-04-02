using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float minDistance = 3f;
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool checkShooting()
    {
        distance = Vector3.Distance(transform.position, target.position);
        bool isShooting = distance > minDistance;
        return isShooting;
    }
}
