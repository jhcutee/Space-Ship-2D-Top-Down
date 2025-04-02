using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjectFly
{
    [SerializeField] private float minCampos = -16f;
    [SerializeField] private float maxCampos = 16f;
    protected override void LoadValue()
    {
        base.LoadValue();
        this.moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GetCamPos();
        //Debug.Log(camPos);
        Vector3 objPos = transform.parent.position;
        camPos.x += Random.Range(minCampos, maxCampos);
        camPos.z += Random.Range(minCampos, maxCampos);

        Vector3 diff = camPos - objPos;
        
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f,0f,rot_z);

        Debug.DrawLine(objPos, camPos,Color.red);
    }
    protected virtual Vector3 GetCamPos()
    {
        if(GameController.Instance == null) return Vector3.zero;
        Vector3 camPos = GameController.Instance.MainCamera.transform.position;
        return camPos;
    }
}
