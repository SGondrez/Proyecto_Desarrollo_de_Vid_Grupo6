
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image healthFill;

    private void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealth;
        }
    }

    private void Start()
    {
        if (playerHealth == null || healthFill == null)
        {
            Debug.LogWarning(
                "HealthUI: Faltan referencias en el Inspector."
            );
            return;
        }

        UpdateHealth(
            playerHealth.CurrentHealth,
            playerHealth.MaxHealth
        );
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealth;
        }
    }

    private void UpdateHealth(int currentHealth, int maxHealth)
    {
        if (healthFill == null)
            return;

        float healthPercentage = maxHealth > 0
            ? (float)currentHealth / maxHealth
            : 0f;

        healthFill.fillAmount = healthPercentage;
    }
}
