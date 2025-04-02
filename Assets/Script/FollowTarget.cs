using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 4f;

    private void FixedUpdate()
    {
        FollowingTarget();
    }
    protected virtual void FollowingTarget()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, Player.position, speed * Time.fixedDeltaTime);
    }
}
