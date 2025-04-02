using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Monobehahaha
{
    [Header("Level")]
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int maxLevel = 99;
    public int CurrenLevel => currentLevel;
    public int MaxLevel => maxLevel;
    protected virtual void LevelUp()
    {
        currentLevel++;
        LevelLimit();
    }
    protected virtual void LevelSet(int Level)
    {
        this.currentLevel = Level;
        LevelLimit();
    }
    protected virtual void LevelLimit()
    {
        if(currentLevel > maxLevel) currentLevel = maxLevel;
        if(currentLevel < 0) currentLevel = 0;
    }
}
