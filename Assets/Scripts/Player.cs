using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthChanger _kitButton;
    [SerializeField] private HealthChanger _damageButton;

    private float _health;
    private float _maxHealth = 100;
    private float _minHealth = 0;

    public event Action<float> HealthChanged;
    public event Action<float> MaxHealthSetted;

    private void Awake()
    {
        _health = _maxHealth;

        MaxHealthSetted?.Invoke(_health);
    }

    private void OnEnable()
    {
        _kitButton.Pressed += OnChangeHealth;
        _damageButton.Pressed += OnChangeHealth;
    }

    private void OnDisable()
    {
        _kitButton.Pressed -= OnChangeHealth;
        _damageButton.Pressed -= OnChangeHealth;
    }

    private void OnChangeHealth(float value)
    {
        _health += value;

        ClampHealth();

        HealthChanged?.Invoke(_health);
    }

    private void ClampHealth()
    {
        if (_health < _minHealth)
            _health = _minHealth;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}
