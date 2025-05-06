using UnityEngine;
using UnityEngine.UIElements;

public class RoomTrigger : MonoBehaviour
{
    public Transform originalPosition; 
    public Transform newPosition;
    private bool isInPositionB = false;
    private bool canTrigger = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canTrigger || !other.CompareTag("Player")) return;

        CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
        if (cam == null)
        {
            Debug.LogWarning("CameraFollow no encontrado en la cámara principal");
            return;
        }

        if (!isInPositionB)
        {
            cam.MoveToRoom(newPosition);
            isInPositionB = true;
        }
        else
        {
            cam.MoveToRoom(originalPosition);
            isInPositionB = false;
        }

        canTrigger = false;
        Debug.Log("Trigger activado, cámara movida");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = true;
        }
    }
}
