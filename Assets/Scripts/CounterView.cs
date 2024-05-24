using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private float _increaseDuration = 0.5f;
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    void Start()
    {
        _counterText.text = _counter.MinValue.ToString();
    }

    private void OnEnable()
    {
        _counter.TriggerTimer += TriggerCounter;
    }

    private void OnDisable()
    {
        _counter.TriggerTimer -= TriggerCounter;
    }

    private void TriggerCounter()
    {
        if(_counter.IsPaused == false)
        {
            StartCoroutine(IncreaseCounter());
        }
    }

    private IEnumerator IncreaseCounter()
    {
        float elapsedTime = 0f;
        while (_counter.IsPaused == false)
        {
            var wait = new WaitForSeconds(_increaseDuration);
            float previousValue = float.Parse(_counterText.text);
            elapsedTime += Time.deltaTime;
            float intermediateValue = previousValue + _counter.Step;
            _counterText.text = intermediateValue.ToString();
            yield return wait;
        }
    }
}
