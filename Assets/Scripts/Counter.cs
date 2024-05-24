using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _step = 1;
    [NonSerialized] public bool IsPaused = true;

    public float MinValue => _minValue;
    public float Step => _step;

    public event Action TriggerTimer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerCounter();
        }   
    }

    public void TriggerCounter()
    {
        IsPaused = !IsPaused;
        TriggerTimer();
    }
}
