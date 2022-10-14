using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void Start()
    {
        MaxValue = _player.MaxHealth;
        Slider.value = 1;
    }
}
