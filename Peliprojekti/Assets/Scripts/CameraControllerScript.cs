using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour

{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;

    [Range(0.1f, 1f)][SerializeField] private float cameraSpeed;
    private Vector3 currentSpeed = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.position + offset, ref currentSpeed, cameraSpeed);
    }
}
