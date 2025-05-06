using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform currentRoomCenter;
    public void MoveToRoom(Transform newRoom)
    {
        if (newRoom == null) return;

        transform.position = new Vector3(newRoom.position.x,newRoom.position.y,transform.position.z);

        currentRoomCenter = newRoom;
    }
}
