using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : Monobehahaha
{
    [Header("ShipMovement")]
    [SerializeField] public Vector3 targetPos;
    [SerializeField] public float speed = 0.5f;
    [SerializeField] public float distance;
    [SerializeField] public float distanceMin = 1f;

    protected virtual void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        this.distance = Vector3.Distance(this.transform.position, this.targetPos);
        if (distance < distanceMin) return;
        Vector3 pos = Vector3.Lerp(this.transform.parent.position, targetPos, speed);
        transform.parent.position = pos;
    }
}
