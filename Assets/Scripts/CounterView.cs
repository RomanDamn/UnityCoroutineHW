using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    void Start()
    {
        _counterText.text = _counter.MinValue.ToString();
    }

    private void OnEnable()
    {
        _counter.ChangeValue += ChangeValue;
    }

    private void OnDisable()
    {
        _counter.ChangeValue -= ChangeValue;
    }

    private void ChangeValue(float value)
    {
        _counterText.text = value.ToString();
    }
}
