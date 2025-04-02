using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnController : Monobehahaha
{
    [SerializeField] private JunkSpawner junkSpawner;
    [SerializeField] private spawnPos spawnPos;
    
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    public spawnPos SpawnPos { get => spawnPos; }

    protected override void LoadComponent()
    {
        this.LoadJunkSpawner();
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
    protected virtual void LoadJunkSpawner()
    {
        if(this.JunkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
        //Debug.Log("LoadJunkSpawner");
    }
    public virtual Transform GetRandomPos()
    {
        int ran = Random.Range(0, spawnPos.LsSpawnPos.Count);
        return spawnPos.LsSpawnPos[ran];
    }

}
