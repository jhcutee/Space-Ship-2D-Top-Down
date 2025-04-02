using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    private Vector3 MousePos;
    [SerializeField] public Vector3 mousePos { get => MousePos; }

    private float onFiring;
    [SerializeField] public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 InputManager allow to exits ");
        instance = this;
    }
    private void Update()
    {
        GetMouseDown();
    }
    void FixedUpdate()
    {
        GetMousePos();
    }
    public virtual void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        onFiring = Input.GetAxis("Fire1");
    }
    
}
