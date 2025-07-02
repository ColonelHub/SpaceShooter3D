using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    public int MaxHealth { get => maxHealth; }

    public event Action OnKilled = null;

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void RecieveDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            OnKilled?.Invoke();
        }
    }
}
