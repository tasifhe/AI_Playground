using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager _inputManager;
    Rigidbody rb;
    Vector3 moveDir;
    Transform cameraObject;

    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 7f;
    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        moveDir = cameraObject.forward * _inputManager.verticalInput;
        moveDir = moveDir + cameraObject.right * _inputManager.horizontalInput;

        moveDir.Normalize();
        moveDir.y = 0;
        moveDir = moveDir * movementSpeed;

        Vector3 movementVelocity = moveDir;
        rb.velocity = movementVelocity;
    }
    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * _inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * _inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}