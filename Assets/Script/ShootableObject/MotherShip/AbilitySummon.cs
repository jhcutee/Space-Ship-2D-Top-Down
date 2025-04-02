using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("AbilitySummon")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] private Abilities abilities;
    public Abilities Abilities => abilities;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = transform.parent.GetComponent<Abilities>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }
    protected virtual void Summoning()
    {
        if (!isReady) return;
        this.Summon();
    }
    protected virtual Transform Summon()
    {
        Vector3 enemySpawnPos = this.abilities.AbilityObjectController.SpawnPos.GetRandom().position;
        Transform enemyPrefab = this.spawner.GetRandomPrefabToSpawn();
        Transform minion = Instantiate(enemyPrefab, enemySpawnPos, this.transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
        return minion;
    }
}
