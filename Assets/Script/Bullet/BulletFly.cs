using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjectFly
{
    protected override void LoadValue()
    {
        base.LoadValue();
        this.moveSpeed = 5.0f;
    }
}
