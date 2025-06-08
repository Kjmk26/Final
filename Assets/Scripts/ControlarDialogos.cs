using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlarDialogos : MonoBehaviour
{
    private Animator animator;
    private Queue<string> colaDialogos;
    ListaTextos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;
    private Coroutine corrutinaActual;

    void Start()
    {
        animator = GetComponent<Animator>();
        colaDialogos = new Queue<string>();
    }
    public void ActivarCartel(ListaTextos textoObjeto)
    {
        animator.SetBool("Cartel", true);
        texto = textoObjeto;
        GameManager.dialogoActivo = true;
        ActivaTexto();
    }

    public void ActivaTexto()
    {
        if (texto == null)
        {
            Debug.LogWarning("Texto no asignado en ControlarDialogos.");
            return;
        }

        colaDialogos.Clear();
        foreach (string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
        SiguienteFrase();
    }

    public void SiguienteFrase()
    {
        if (colaDialogos.Count == 0)
        {
            CierraCartel();
            return;
        }

        string fraseActual = colaDialogos.Dequeue();

        if (corrutinaActual != null)
        {
            StopCoroutine(corrutinaActual);
        }

        corrutinaActual = StartCoroutine(MostrarCaracteres(fraseActual));
    }

    IEnumerator MostrarCaracteres (string textoMostrar)
    {
        textoPantalla.text = "";
        foreach (char caracter in textoMostrar.ToCharArray())
        {
            textoPantalla.text += caracter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void CierraCartel()
    {
        animator.SetBool("Cartel", false);
        GameManager.dialogoActivo = false;
    }

    public bool EstaCartelActivo()
    {
        return animator.GetBool("Cartel");
    }
}
