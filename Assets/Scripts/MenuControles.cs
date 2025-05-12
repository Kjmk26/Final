using System.Collections;
using UnityEngine;

public class MenuControles : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup canvasGroup;

    void Start()
    {
        // Asegura que el panel esté oculto al iniciar
        OcultarPanel();
    }

    public void AbrirPanel()
    {
        if (canvasGroup != null && animator != null)
        {
            // Resetea los triggers antes de abrir
            animator.ResetTrigger("Close");
            animator.SetTrigger("Open");

            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
    }

    public void CerrarPanel()
    {
        if (animator != null)
        {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");

            StartCoroutine(DesactivarPanelDespuesDeAnimacion());
        }
    }

    private IEnumerator DesactivarPanelDespuesDeAnimacion()
    {
        yield return new WaitForSeconds(0.5f); // Espera a que termine la animación
        OcultarPanel();
    }

    private void OcultarPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        if (animator != null)
        {
            animator.ResetTrigger("Open");
            animator.ResetTrigger("Close");
            animator.Play("Idle"); // Asegura que vuelve al estado inicial
        }
    }
}
