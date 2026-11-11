using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [Header("Configuración del NPC")]
    [SerializeField] private string npcName = "Aldeano";

    [TextArea(2, 4)]
    [SerializeField]
    private string[] dialogues =
    {
        "Hola, Clary",
        "Este mundo está lleno de misterios y peligros.",
        "Ten cuidado durante tu aventura."
    };

    [Header("Interfaz")]
    [SerializeField] private InteractionUI interactionUI;

    private bool playerNearby = false;
    private bool dialogueActive = false;
    private int currentDialogueIndex = 0;

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
            ShowInteractionPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = false;
            EndDialogue(false);
        }
    }

    private void Interact()
    {
        if (interactionUI == null)
        {
            Debug.LogWarning("InteractionUI no está asignado.");
            return;
        }

        if (dialogues == null || dialogues.Length == 0)
        {
            Debug.LogWarning("El NPC no tiene diálogos.");
            return;
        }

        if (!dialogueActive)
        {
            dialogueActive = true;
            currentDialogueIndex = 0;
        }

        if (currentDialogueIndex < dialogues.Length)
        {
            string message =
                npcName + ": " + dialogues[currentDialogueIndex];

            interactionUI.ShowMessage(message);
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue(true);
        }
    }

    private void ShowInteractionPrompt()
    {
        if (interactionUI != null)
        {
            interactionUI.ShowMessage(
                "Presiona E para hablar con " + npcName
            );
        }
    }

    private void EndDialogue(bool showPrompt)
    {
        dialogueActive = false;
        currentDialogueIndex = 0;

        if (interactionUI == null)
            return;

        if (showPrompt && playerNearby)
        {
            ShowInteractionPrompt();
        }
        else
        {
            interactionUI.HideMessage();
        }
    }
}