using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _step = 1;
    [SerializeField] private float _increaseDuration = 0.5f;

    private bool _isPaused = true;
    private float _currentValue;
    private Coroutine _runningCoroutine;
    private WaitForSeconds _wait;

    public float MinValue = 0;
    public event Action<float> ValueChanged;

    private void Start()
    {
        _currentValue = MinValue;
        _wait = new WaitForSeconds(_increaseDuration);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPaused = !_isPaused;

            if (_isPaused == false)
            {
                StartCounter();
            }
            else
            {
                PauseCounter();
            }
        }
    }

    private void StartCounter()
    {
        _runningCoroutine = StartCoroutine(IncreaseCounter());
    }

    private void PauseCounter()
    {
        StopCoroutine(_runningCoroutine);
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            float previousValue = _currentValue;
            _currentValue = previousValue + _step;
            ValueChanged?.Invoke(_currentValue);
            yield return _wait;
        }
    }
}
