
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private TMP_Text interactionText;

    private void Start()
    {
        HideMessage();
    }

    public void ShowMessage(string message)
    {
        if (interactionPanel == null || interactionText == null)
        {
            Debug.LogWarning("La interfaz no está configurada.");
            return;
        }

        interactionText.text = message;
        interactionPanel.SetActive(true);
    }

    public void HideMessage()
    {
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(false);
        }
    }
}
