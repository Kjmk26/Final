using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void ReproducirSonido()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
