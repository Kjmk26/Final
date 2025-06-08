using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinuarManager : MonoBehaviour
{
    public Button continuarButton;  // Asignado desde el inspector

    void Start()
    {
        // Si hay un nivel guardado, activar el botón
        if (PlayerPrefs.HasKey("NivelGuardado") && !string.IsNullOrEmpty(PlayerPrefs.GetString("NivelGuardado")))
        {
            continuarButton.gameObject.SetActive(true);
            continuarButton.onClick.AddListener(CargarNivelGuardado);
        }
        else
        {
            continuarButton.gameObject.SetActive(false);
        }
    }

    void CargarNivelGuardado()
    {
        string nivelGuardado = PlayerPrefs.GetString("NivelGuardado", "");

        if (string.IsNullOrEmpty(nivelGuardado))
        {
            Debug.LogWarning("No se encontró un nivel guardado válido.");
            return;
        }

        Debug.Log("Cargando nivel guardado: " + nivelGuardado);
        SceneManager.LoadScene(nivelGuardado);
    }
}