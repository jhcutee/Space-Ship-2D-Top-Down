using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitShooting : Shooting
{
    protected override bool checkShooting()
    {
        return InputManager.Instance.OnFiring == 1;
    }
}
