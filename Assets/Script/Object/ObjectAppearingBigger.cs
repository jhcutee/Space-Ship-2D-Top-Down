using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearingBigger : ObjectAppearing
{
    [Header("ObjectAppearingBigger")]
    [SerializeField] protected float speedAppear = 0.01f;
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }
    protected override void Appearing()
    {
        currentScale += speedAppear;
        this.transform.parent.localScale = new Vector3(currentScale, currentScale, currentScale);
        if (currentScale > maxScale) Appear();
    }
    protected virtual void InitScale()
    {
        this.transform.parent.localScale = Vector3.zero;
        currentScale = startScale;
    }
    public override void Appear()
    {
        base.Appear();
        this.transform.parent.localScale = new Vector3(maxScale, maxScale, maxScale);
    }
}
