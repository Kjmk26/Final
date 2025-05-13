using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public ListaTextos textos;

    private void OnMouseDown()
    {
        FindObjectOfType<ControlarDialogos>().ActivarCartel(textos);
    }
}