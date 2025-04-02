using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonMinion : AbilitySummon
{
    public List<Transform> minions;
    public int minionSpawnLimit = 4;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ClearDeadMinion();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSpawner();
    }
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<Spawner>();
    }
    protected override void Summoning()
    {
        if (minions.Count >= minionSpawnLimit) return;
        base.Summoning();
    }
    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.Abilities.AbilityObjectController.transform;
        this.minions.Add(minion);
        return minion;
        
    }
    protected virtual void ClearDeadMinion()
    {
        foreach(Transform minion in minions)
        {
            if(minion.gameObject.activeSelf == false)
            {
                minions.Remove(minion);
                return;
            }
        }
    }
}
