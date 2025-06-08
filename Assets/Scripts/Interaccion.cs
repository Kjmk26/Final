using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Interaccion : MonoBehaviour
{
    public ListaTextos textos;
    private bool jugadorEnZona = false;

    void Update()
    {
        if (jugadorEnZona && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<ControlarDialogos>().ActivarCartel(textos);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
        }
    }
}