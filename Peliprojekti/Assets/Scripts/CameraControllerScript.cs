using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour

{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;

    //[SerializeField] private Vector3 minValues, maxValues;

    //public float dampTime = 0.15f;

    [Range(0.1f, 1f)][SerializeField] private float cameraSpeed;
    private Vector3 currentSpeed = Vector3.zero;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.position + offset, ref currentSpeed, cameraSpeed);

        //CameraBounds();

    }

    /*void CameraBounds()
    {
        Vector3 target = Player.position + offset;

        Vector3 bounds = new Vector3(Mathf.Clamp(target.x, minValues.x, maxValues.x), Mathf.Clamp(target.y, minValues.y, maxValues.y), Mathf.Clamp(target.z, minValues.z, maxValues.z));

        Vector3 boundPosition = Vector3.Lerp(transform.position, bounds, cameraSpeed * Time.deltaTime);

        transform.position = boundPosition;

        Vector3.SmoothDamp(transform.position, target, ref currentSpeed, cameraSpeed, dampTime * Time.deltaTime);

    }*/
}
