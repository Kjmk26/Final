using UnityEngine;

public class CambioPosicionZ : MonoBehaviour
{
    [Tooltip("Arrastra aqu� el objeto que cambiar� su posici�n Z")]
    public GameObject objetoObjetivo;

    [Tooltip("Valor Z original del objeto")]
    public float zOriginal = -2f;

    [Tooltip("Valor Z al que se mover� cuando el jugador entre")]
    public float zFrente = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objetoObjetivo != null)
        {
            Vector3 nuevaPos = objetoObjetivo.transform.position;
            nuevaPos.z = zFrente;
            objetoObjetivo.transform.position = nuevaPos;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objetoObjetivo != null)
        {
            Vector3 nuevaPos = objetoObjetivo.transform.position;
            nuevaPos.z = zOriginal;
            objetoObjetivo.transform.position = nuevaPos;
        }
    }
}
