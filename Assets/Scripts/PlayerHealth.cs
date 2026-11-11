
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de salud")]
    [SerializeField] private int maxHealth = 100;

    public int MaxHealth => maxHealth;
    public int CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    public event Action<int, int> OnHealthChanged;

    private void Awake()
    {
        maxHealth = Mathf.Max(1, maxHealth);
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsDead)
            return;

        CurrentHealth = Mathf.Max(
            CurrentHealth - damage, 0
        );

        Debug.Log(
            "Clary recibió daño. Salud: " +
            CurrentHealth + "/" + maxHealth
        );

        OnHealthChanged?.Invoke(
            CurrentHealth, maxHealth
        );

        if (IsDead)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || IsDead)
            return;

        CurrentHealth = Mathf.Min(
            CurrentHealth + amount, maxHealth
        );

        Debug.Log(
            "Clary recuperó salud. Salud: " +
            CurrentHealth + "/" + maxHealth
        );

        OnHealthChanged?.Invoke(
            CurrentHealth, maxHealth
        );
    }

    private void Die()
    {
        Debug.Log("Clary ha muerto.");

      
        PlayerMovement movement =
            GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.enabled = false;
        }

       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    [ContextMenu("Prueba - Recibir 20 de daño")]
    private void TestDamage()
    {
        TakeDamage(20);
    }

    [ContextMenu("Prueba - Recuperar 15 de salud")]
    private void TestHeal()
    {
        Heal(15);
    }

    [ContextMenu("Prueba - Daño letal")]
    private void TestDeath()
    {
        TakeDamage(maxHealth);
    }
}

