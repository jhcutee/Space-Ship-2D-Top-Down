using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPos : Monobehahaha
{
    [SerializeField] private List<Transform> lsSpawnPos;

    public List<Transform> LsSpawnPos { get => lsSpawnPos; }

    protected override void LoadComponent()
    {
        LoadList();
    }
    protected virtual void LoadList()
    {
        if (lsSpawnPos.Count > 0) return;
        Transform _spawnPos = this.transform;
        foreach (Transform obj in _spawnPos)
        {
            lsSpawnPos.Add(obj);
        }
        
        //Debug.Log("LoadList!!!");
    }
    public virtual Transform GetRandom()
    {
        int ran = UnityEngine.Random.Range(0, LsSpawnPos.Count);
        return lsSpawnPos[ran];
    }

}
