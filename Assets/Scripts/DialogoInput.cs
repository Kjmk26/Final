using UnityEngine;

public class DialogoInput : MonoBehaviour
{
    public ControlarDialogos controlador;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controlador.EstaCartelActivo())
        {
            controlador.SiguienteFrase();
        }   
    }
}
