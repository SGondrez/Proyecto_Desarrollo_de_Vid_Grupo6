
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [Header("Configuración del daño")]
    [SerializeField] private int damageAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth =
            other.GetComponent<PlayerHealth>();

        if (playerHealth != null && !playerHealth.IsDead)
        {
            playerHealth.TakeDamage(damageAmount);

            Debug.Log(
                "Clary entró en una zona peligrosa."
            );
        }
    }
}
