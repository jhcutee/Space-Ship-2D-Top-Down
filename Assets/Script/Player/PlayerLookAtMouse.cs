using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerLookAtMouse : ObjectLookAtTarget
{
    protected override void FixedUpdate()
    {
        GetMousePos();
        base.FixedUpdate();
    }
    protected virtual void GetMousePos()
    {
        this.targetPos = InputManager.Instance.mousePos;
        this.targetPos.z = 0;
    }
}
