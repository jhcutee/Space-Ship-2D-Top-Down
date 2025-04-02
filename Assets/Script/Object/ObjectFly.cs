using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : Monobehahaha
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        Fly();
    }
    void Fly()
    {
        this.transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
