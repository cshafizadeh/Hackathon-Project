using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 100.0f;

    private Rigidbody rb;
    private float verticalLookRotation = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent Rigidbody from rotating with physics forces
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);
    }

    void FixedUpdate()
    {
        // Player movement
        float translation = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        Vector3 move = transform.right * strafe + transform.forward * translation;
        rb.MovePosition(rb.position + move);
    }
}
