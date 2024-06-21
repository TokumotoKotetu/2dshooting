using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTr;
    [SerializeField] Vector3 cameraOrgPos = new Vector3(0, 0, -10f);
    [SerializeField] Vector2 cameraMaxPos = new Vector2(0, 5);
    [SerializeField] Vector2 cameraMinPos = new Vector2(-5, -5);


    void LateUpdate()
    {
        Vector3 playerPos = playerTr.position;
        Vector3 camPos = transform.position;

        camPos = Vector3.Lerp(transform.position, playerPos + cameraOrgPos, 3.0f * Time.deltaTime);

        camPos.x = Mathf.Clamp(camPos.x, cameraMinPos.x, cameraMaxPos.x);
        camPos.y = Mathf.Clamp(camPos.y, cameraMinPos.y, cameraMaxPos.y);
        camPos.z = -10f;
        transform.position = camPos;
    }
}
