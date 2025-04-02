using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distanceLimit=40f;
    [SerializeField] protected Transform mainCamenra;
    // Start is called before the first frame update
    protected override void LoadComponent()
    {
        LoadCamera();
    }
    protected void LoadCamera()
    {
        if (mainCamenra != null) return;
        mainCamenra = Transform.FindAnyObjectByType<Camera>().transform;
        Debug.Log("LoadCamenra");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override bool CanDead()
    {
        distance = Vector3.Distance(mainCamenra.position, transform.parent.position);
        if (distance < distanceLimit) return false;
        return true;
    }
}
