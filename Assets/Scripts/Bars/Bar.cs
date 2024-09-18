using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _bar;

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
        _bar.value = value;
    }
}
