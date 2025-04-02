using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Monobehahaha
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private spawnPos spawnPos;

    public Spawner Spawner { get => spawner; }
    public spawnPos SpawnPos { get => spawnPos; }

    protected override void LoadComponent()
    {
        this.LoadSpawner();
        this.LoadSpawnPos();
    }
    protected virtual void LoadSpawnPos()
    {
        if (this.spawnPos != null) return;
        spawnPos = Transform.FindAnyObjectByType<spawnPos>();
        if (spawnPos == null) Debug.Log("ALO NULL R");
        //Debug.Log("LoadSpawnPos");
    }

    // Update is called once per frame
    protected virtual void LoadSpawner()
    {
        if (this.Spawner != null) return;
        spawner = GetComponent<Spawner>();
        //Debug.Log("LoadJunkSpawner");
    }
    public virtual Transform GetRandomPos()
    {
        int ran = Random.Range(0, spawnPos.LsSpawnPos.Count);
        return spawnPos.LsSpawnPos[ran];
    }
}
