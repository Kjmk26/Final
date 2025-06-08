using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCasas : MonoBehaviour
{
    public List<GameObject> objetosAnimados; // Lista de objetos a activar/desactivar

    private bool enZona = false;

    void Start()
    {
        foreach (GameObject obj in objetosAnimados)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E presionada.");
            // Aquí puedes hacer algo, como cambiar de escena o reproducir sonido
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enZona = true;
            foreach (GameObject obj in objetosAnimados)
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enZona = false;
            foreach (GameObject obj in objetosAnimados)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
}