using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private bool isGrounded;
    private float runSpeed = 10f;
    [SerializeField] private float jumpHeight = 6f;
    [SerializeField] private float gravity = -9.81f;
    private float velocityY = 0.0f;
    private bool canDoubleJump;
    private float mouseSensitvity = 2f;
    [SerializeField] private float upDownRange = 35f;
    private Camera mainCamera;
    private float verticalRotation;


    void Start()
    {
       
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
    
        HandleMovement();
        HandleRotation();

    }


    private void HandleMovement()
    {
        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputDir.Normalize();

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * runSpeed + Vector3.up * velocityY;

        isGrounded = characterController.isGrounded;


        if (isGrounded)
        {
            velocityY = 0.0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocityY = jumpHeight;
                canDoubleJump = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump)
        {

            canDoubleJump = false;
            velocityY += jumpHeight;

        }

        velocity.y = velocityY;
        characterController.Move(velocity * Time.deltaTime);

    }

    private void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis("Mouse X") * mouseSensitvity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitvity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

}