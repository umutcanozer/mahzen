using BG.Core;
using BGCore;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BGMovement
{
    public class PlayerLocomotion : MonoBehaviour
    {
        InputManager inputManager;

        public float movementVel;
        Vector3 moveDirection;
        Vector3 targetDirection;
        Vector3 rollDirection;

        Rigidbody rb;
        AnimationManager animationManager;

        [SerializeField] float movementSpeed = 7f;
        [SerializeField] float rotateSpeed = 15.0f;
        [SerializeField] float groundDrag = 5.0f;
        bool isMoving = false;
        private void Start()
        {
            inputManager = GetComponent<InputManager>();
            rb = GetComponent<Rigidbody>();
            animationManager = GetComponent<AnimationManager>();
        }

        public bool IsMoving { get => isMoving; }
        private void Update()
        {   
            Debug.Log(movementVel);

        }
        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
            MovementState();
        }

        private void HandleMovement()
        {
            moveDirection = new Vector3(inputManager.verticalInput, 0f,-inputManager.horizontalInput);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1);

            moveDirection *= movementSpeed;


            Vector3 movementVelocity = moveDirection;
            rb.drag = groundDrag;
            rb.AddForce(movementVelocity * 10f, ForceMode.Force);
            animationManager.UpdateMoveAnimation(rb.velocity.magnitude);
        }

        private void HandleRotation()
        {
            targetDirection = Vector3.zero;
            targetDirection = new Vector3(inputManager.verticalInput, 0f, -inputManager.horizontalInput);
            targetDirection = Vector3.ClampMagnitude(targetDirection, 1);


            if (targetDirection == Vector3.zero) targetDirection = transform.forward;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            transform.rotation = playerRotation;

            
        }
        private void MovementState()
        {
            float velocity = rb.velocity.magnitude;

            if (velocity > 1f) isMoving = true;
            else if (velocity < 0.1f) isMoving = false;
        }
    }
}
