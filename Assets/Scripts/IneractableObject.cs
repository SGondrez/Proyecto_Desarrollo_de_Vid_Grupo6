
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Configuración de interacción")]
    [SerializeField]
    private string interactionMessage =
        "Has interactuado con el objeto.";

    [SerializeField] private InteractionUI interactionUI;

    private bool playerNearby = false;

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = true;
            Debug.Log("Presiona E para interactuar.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = false;

            if (interactionUI != null)
            {
                interactionUI.HideMessage();
            }
        }
    }

    private void Interact()
    {
        if (interactionUI != null)
        {
            interactionUI.ShowMessage(interactionMessage);
        }
        else
        {
            Debug.LogWarning(
                "No se ha asignado InteractionUI."
            );
        }
    }
}
