using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxHealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _player.MaxHealthSetted += OnDisplayMaxHealth;
    }

    private void OnDisable()
    {
        _player.MaxHealthSetted -= OnDisplayMaxHealth;
    }

    private void OnDisplayMaxHealth(float value)
    {
        _text.text = value + _text.text + value;
    }
}
