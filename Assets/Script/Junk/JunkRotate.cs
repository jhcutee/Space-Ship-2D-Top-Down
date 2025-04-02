using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] private float speed = 15f;
    protected virtual void FixedUpdate()
    {
        RotateJunk();
    }
    protected virtual void RotateJunk()
    {
        Vector3 eulers = new Vector3(0,0,1);
        this.JunkController.Model.Rotate(eulers * speed * Time.fixedDeltaTime);
    }

}
