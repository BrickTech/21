using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Button _button;

    public event Action<float> Pressed;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHealth);
    }

    private void ChangeHealth()
    {
        Pressed?.Invoke(_value);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHealth);
    }
}
