using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseXSpeed = 6f;
    public float mouseYSpeed = 2.5f;
    public float moveSpeed = 3.0f;

    private Vector2 rotation;

    void Setup()
    {
	rotation = transform.eulerAngles;
    }

    void Update()
    {
	// move camera
	rotation.y += Input.GetAxis("Mouse X") * mouseXSpeed;
	rotation.x += -Input.GetAxis("Mouse Y") * mouseYSpeed;
	transform.eulerAngles = (Vector2)rotation;
    }

    void FixedUpdate()
    {
        Vector3 horiz = Input.GetAxis("Horizontal") * transform.right;
	Vector3 vert = Input.GetAxis("Vertical") * transform.forward;
	Vector3 jump = Input.GetAxis("Jump") * transform.up;
	transform.position += (horiz + jump + vert) * moveSpeed * Time.deltaTime;
	
    }
}
