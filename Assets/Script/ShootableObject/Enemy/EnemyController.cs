using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AbilityObjectController
{
    protected override string GetTypeToString()
    {
        return ObjectType.Enemy.ToString();
    }
}
