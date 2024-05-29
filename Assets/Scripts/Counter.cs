using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _step = 1;
    [SerializeField] private float _increaseDuration = 0.5f;

    public float MinValue => _minValue;

    private bool _isPaused = true;
    private float _currentValue;
    private int _leftMouseButtonNumber = 0;
    private Coroutine _runningCoroutine;
    private WaitForSeconds _wait;

    public event Action<float> ValueChanged;

    private void Start()
    {
        _currentValue = _minValue;
        _wait = new WaitForSeconds(_increaseDuration);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonNumber))
        {
            _isPaused = !_isPaused;

            if (_isPaused == false)
            {
                Run();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Run()
    {
        _runningCoroutine = StartCoroutine(IncreaseCounter());
    }

    private void Pause()
    {
        StopCoroutine(_runningCoroutine);
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            _currentValue += _step;
            ValueChanged?.Invoke(_currentValue);
            yield return _wait;
        }
    }
}
