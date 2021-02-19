using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Player : MonoBehaviour
{
    private float _health = .5f;

    public event UnityAction ValueChanged;
    public float Health => _health;

    private void OnValidate()
    {
        _health = Mathf.Clamp(_health, 0f, 1f);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage / 100;
        ValueChanged?.Invoke();
        OnValidate();
    }

    public void Cure(float health)
    {
        _health += health / 100;
        ValueChanged?.Invoke();
        OnValidate();
    }
}
