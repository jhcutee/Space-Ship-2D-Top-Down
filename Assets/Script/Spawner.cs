using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : Monobehahaha
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> myPool;
    [SerializeField] protected Transform holder;
    public int spawnCount = 0;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadList();
        LoadHolder();
    }
    protected virtual void LoadList()
    {
        if (prefabs.Count > 0) return;
        Transform prefabObjs = transform.Find("Prefabs");
        foreach (Transform obj in prefabObjs)
        {
            prefabs.Add(obj);
        }
        HidePrefab();
        //Debug.Log("LoadList!!!");
    }
    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        //Debug.Log("LoadHolder");
    }
    protected virtual void HidePrefab()
    {
        foreach(Transform obj in prefabs)
        {
            obj.gameObject.SetActive(false);
        }
        //Debug.Log("Hide Prefab");
    }
    public virtual Transform Spawm(string prefabName,Vector3 pos, Quaternion rotation)
    {
        Transform obj = GetObjByName(prefabName);
        if (obj == null) { Debug.Log("Can not cant find prefab"); return null; }

        return this.Spawm(obj, pos, rotation);
    }
    public virtual Transform Spawm(Transform prefab, Vector3 pos, Quaternion rotation)
    {

        Transform temp = GetObjectFromPool(prefab);
        temp.position = pos;
        temp.rotation = rotation;
        temp.parent = this.holder;
        spawnCount++;
        return temp;
    }
    protected virtual Transform GetObjByName(string prefabName)
    {
        foreach(Transform obj in prefabs)
        {
            if(obj.name == prefabName) return obj;
        }
        return null;
    }
    protected virtual Transform GetObjectFromPool(Transform obj)
    {
        foreach(Transform pool in myPool)
        {
            if(pool.name == obj.name)
            {
                myPool.Remove(pool);    
                return pool;
            }
        }
        Transform _pool = Instantiate(obj);
        _pool.name = obj.name;
        return _pool;
    }
    public virtual void Despawn(Transform obj)
    {
        myPool.Add(obj);
        obj.gameObject.SetActive(false);
        spawnCount--;
    }
    public virtual Transform GetRandomPrefabToSpawn()
    {
        int ran = Random.Range(0,prefabs.Count);
        return prefabs[ran];

    }
}
