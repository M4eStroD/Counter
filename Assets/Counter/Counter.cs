using UnityEngine;
using TMPro;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _periodIncrease = 0.5f;
    [SerializeField] private int _valueIncrease = 1;
    [SerializeField] private TextMeshProUGUI _counter;

    private Coroutine _tempCounter;

    private int _currentCount = 0;

    private void Start()
    {
        _counter.text = _currentCount.ToString();
    }

    public void StartCounter()
    {
        StopCounter();

        _tempCounter = StartCoroutine(IncreaseCounter());
    }

    public void StopCounter()
    {
        if (_tempCounter != null)
            StopCoroutine(_tempCounter);
    }

    private IEnumerator IncreaseCounter()
    {
        var wait = new WaitForSeconds(_periodIncrease);

        while (true)
        {
            _currentCount += _valueIncrease;
            _counter.text = _currentCount.ToString();
            yield return wait;
        }
    }
}
