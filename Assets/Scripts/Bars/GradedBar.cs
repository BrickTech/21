using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GradedBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _bar;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private float _minValue = 0f;
    private float _maxValue = 100f;
    

    private void Awake()
    {
        _bar.maxValue = _maxValue;
        _bar.minValue = _minValue;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeValue;
    }

    private void OnChangeValue(float value)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MovingSmoothly(value));
    }

    private IEnumerator MovingSmoothly(float value)
    {
        while (_bar.value != value)
        {
            yield return null;

            _bar.value = Mathf.MoveTowards(_bar.value, value, _speed * Time.deltaTime);
        }
    }
}
