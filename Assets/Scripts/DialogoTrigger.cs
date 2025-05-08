using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    public ControlarDialogos controladorDialogos;
    public ListaTextos textoDialogo;

    private bool jugadorEnZona = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controladorDialogos.ActivarCartel(textoDialogo);
            jugadorEnZona = true;
        }
    }

    void Update()
    {
        if (jugadorEnZona && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            controladorDialogos.SiguienteFrase();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
        }
    }
}
