
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Configuración de curación")]
    [SerializeField] private int healAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth =
            other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            return;

      
        if (playerHealth.IsDead)
            return;

      
        if (playerHealth.CurrentHealth >= playerHealth.MaxHealth)
            return;

       
        playerHealth.Heal(healAmount);

        Debug.Log("Clary recogió un objeto de curación.");

       
        Destroy(gameObject);
    }
}
