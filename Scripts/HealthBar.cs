using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private Player _player;
    private float _currentValue;
    private float _changeTime = .5f;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health;
    }

    private void OnEnable()
    {
        _player.ValueChanged += CheckChangedIsHealth;
    }

    private void OnDisable()
    {
        _player.ValueChanged -= CheckChangedIsHealth;
    }

    private void CheckChangedIsHealth()
    {
        if (_player.Health != _currentValue)
        {
            _currentValue = _player.Health;
            DrawHealthBar();
        }
    }

    private void DrawHealthBar()
    {
        _slider.DOValue(_player.Health, _changeTime, false);
    }
}
