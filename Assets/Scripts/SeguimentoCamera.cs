using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamera : MonoBehaviour
{
    public void MoveToRoom(Transform targetRoom)
    {
        transform.position = new Vector3(targetRoom.position.x, targetRoom.position.y, transform.position.z);
    }
}