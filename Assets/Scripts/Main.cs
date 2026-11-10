using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class Main : MonoBehaviour
{
    [Header("Pantallas")]
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject lobbyScreen;

    [Header("Escenario")]
    [SerializeField] private string escenario1 = "Escenario1"; // nombre exacto de tu escena

    private bool started = false;

    void Start()
    {
        titleScreen.SetActive(true);
        lobbyScreen.SetActive(false);
    }

    void Update()
    {
        if (started) return;

        if (SpacePressed())
        {
            started = true;
            titleScreen.SetActive(false);
            lobbyScreen.SetActive(true);
        }
    }

    // Se conecta al botón Start del lobby
    public void StartGame()
    {
        SceneManager.LoadScene(escenario1);
    }

    private bool SpacePressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
#else
        return Input.GetKeyDown(KeyCode.Space);
#endif
    }
}