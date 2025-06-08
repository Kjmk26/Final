using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPuerta : MonoBehaviour
{
    [Header("Configuración de transición")]
    public string nombreEscenaDestino;
    public string nombrePuntoDestino; // <-- Esta variable cambia por cada puerta

    private bool enZona = false;

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            // Guardar el nombre del punto de entrada
            PlayerPrefs.SetString("PuntoEntrada", nombrePuntoDestino);

            // Cargar la escena de destino
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            enZona = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            enZona = false;
    }
}