using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnRandom : Monobehahaha
{
    [SerializeField] private JunkSpawnController junkController;
    public JunkSpawnController JunkController { get => junkController; }

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
        if (this.junkController != null) return;
        junkController = GetComponent<JunkSpawnController>();
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

        Transform ranPos = this.JunkController.GetRandomPos();
        Quaternion rot = this.transform.rotation;
        Transform randomJunk = this.JunkController.JunkSpawner.GetRandomPrefabToSpawn();
        Transform temp = this.junkController.JunkSpawner.Spawm(randomJunk, ranPos.position, rot);
        temp.gameObject.SetActive(true);
    }
    protected virtual bool CheckLimitSpawn()
    {
        int currentSpawnCount = this.JunkController.JunkSpawner.spawnCount;
        return currentSpawnCount >= spawnLimit;
    }

}
