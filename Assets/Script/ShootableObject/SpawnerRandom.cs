using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : Monobehahaha
{
    [SerializeField] private SpawnerController spawnerController;
    public SpawnerController SpawnerController { get => spawnerController; }

    public float timeDelay = 4f;
    public float timeCount = 0f;
    public int spawnLimit = 9;

    protected override void LoadComponent()
    {
        this.LoadJunkController();

    }

    // Update is called once per frame
    protected virtual void LoadJunkController()
    {
        if (this.spawnerController != null) return;
        spawnerController = GetComponent<SpawnerController>();
        //Debug.Log("JunkController");
    }

    protected virtual void FixedUpdate()
    {
        JunkSpawn();
    }
    protected virtual void JunkSpawn()
    {
        if (CheckLimitSpawn()) return;
        timeCount += Time.fixedDeltaTime;
        if (timeCount < timeDelay) return;
        timeCount = 0f;

        Transform ranPos = this.SpawnerController.GetRandomPos();
        Quaternion rot = this.transform.rotation;
        Transform randomJunk = this.SpawnerController.Spawner.GetRandomPrefabToSpawn();
        Transform temp = this.spawnerController.Spawner.Spawm(randomJunk, ranPos.position, rot);
        temp.gameObject.SetActive(true);
    }
    protected virtual bool CheckLimitSpawn()
    {
        int currentSpawnCount = this.SpawnerController.Spawner.spawnCount;
        return currentSpawnCount >= spawnLimit;
    }

}
