using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _step = 1;
    [SerializeField] private float _increaseDuration = 0.5f;

    private bool IsPaused = true;
    private float _currentValue;

    public event Action<float> ChangeValue;
    public float MinValue => _minValue;
    public float Step => _step;

    private void Start()
    {
        _currentValue = _minValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }   
    }

    private void ToggleCounter()
    {
        IsPaused = !IsPaused;

        if (IsPaused == false)
        {
            StartCoroutine(IncreaseCounter());
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (IsPaused == false)
        {
            var wait = new WaitForSeconds(_increaseDuration);
            float previousValue = _currentValue;
            float intermediateValue = previousValue + _step;
            _currentValue = intermediateValue;
            ChangeValue(_currentValue);
            yield return wait;
        }
    }
}
