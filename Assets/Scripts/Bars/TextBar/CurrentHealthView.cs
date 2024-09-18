using System;
using TMPro;
using UnityEngine;

public class CurrentHealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private char _seporator = '/';

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
        _text.text = value + _text.text.Substring(_text.text.IndexOf(_seporator));
    }
}
