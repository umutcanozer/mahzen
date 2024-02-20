using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGMovement
{
    public class InputManager : MonoBehaviour
    {
        PlayerControls playerControls;
        Vector2 movementInput;

        public float verticalInput;
        public float horizontalInput;

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                //tusa basildiginda basilan tusa gore deger okur
                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
        }
        private void HandleMovementInput()
        {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;

            Debug.Log("Vertical Input: " + verticalInput);
            Debug.Log("Horizontal Input: " + horizontalInput);
        }
    }
}
