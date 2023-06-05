using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float padding;

    Vector3 moveDir;
    private float zoomScroll;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        if (-10 < mousePos.x && mousePos.x <= padding)
            moveDir.x = -1;
        else if (Screen.width - padding <= mousePos.x && mousePos.x <= Screen.width + 10)
            moveDir.x = 1;
        else
            moveDir.x = 0;

        if (-10 < mousePos.y && mousePos.y <= padding)
            moveDir.y = -1;
        else if (Screen.height - padding <= mousePos.y && mousePos.y <= Screen.height + 10)
            moveDir.y = 1;
        else
            moveDir.y = 0;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomSpeed * zoomScroll * Time.deltaTime, Space.Self);
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }
}
