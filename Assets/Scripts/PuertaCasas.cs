using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCasas : MonoBehaviour
{
    public SpriteRenderer iconoRenderer;
    public Sprite iconoE;

    public string nombreEscenaDestino;
    public string nombrePuntoLlegada; // El nombre del GameObject vacío en la nueva escena

    private bool enZona = false;

    void Start()
    {
        if (iconoRenderer != null)
            iconoRenderer.enabled = false;
        else
            Debug.LogError("iconoRenderer no está asignado.");
    }

    void Update()
    {
        if (enZona)
        {
            iconoRenderer.enabled = true;
            iconoRenderer.sprite = iconoE;

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetString("PuntoLlegada", nombrePuntoLlegada); // Guardar nombre del punto
                SceneManager.LoadScene(nombreEscenaDestino); // Cargar la nueva escena
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            enZona = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enZona = false;
            if (iconoRenderer != null)
                iconoRenderer.enabled = false;
        }
    }
}