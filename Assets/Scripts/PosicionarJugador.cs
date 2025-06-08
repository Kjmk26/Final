using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarJugador : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("PuntoEntrada"))
        {
            string nombrePunto = PlayerPrefs.GetString("PuntoEntrada");

            GameObject punto = GameObject.Find(nombrePunto);
            if (punto != null)
            {
                transform.position = punto.transform.position;
            }
            else
            {
                Debug.LogWarning("No se encontró un punto de entrada llamado: " + nombrePunto);
            }

            PlayerPrefs.DeleteKey("PuntoEntrada");
        }
    }
}