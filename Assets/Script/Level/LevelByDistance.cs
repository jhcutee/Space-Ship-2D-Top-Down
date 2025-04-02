using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("LevelByDistance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel =10f;

    protected virtual void FixedUpdate()
    {
        Leveling();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    public virtual void Leveling()
    {
        if (target == null) return;
        distance = Vector3.Distance(transform.position, target.position);
        int newLevel = GetLevelByDis();
        this.LevelSet(newLevel);
    }
    public int GetLevelByDis()
    {
        return Mathf.FloorToInt(distance/distancePerLevel)+1;
    }
}
