using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera;
    public Transform Player;

    void Update()
    {
     Camera.transform.position = new Vector3(0, 20, Player.position.z);
    }
}
