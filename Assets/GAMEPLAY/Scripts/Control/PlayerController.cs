using BGCombat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using BGCore;
using BGMovement;
using BGDialogue;

namespace BGControl
{
    public class PlayerController : MonoBehaviour
    {

        InputManager inputManager;
        PlayerLocomotion playerLocomotion;

        Health _health;
        Fighter _fighter;
        [SerializeField] DialogueManager dialogueManager;
        void Start()
        {
            _health = GetComponent<Health>();
            _fighter = GetComponent<Fighter>();
            inputManager = GetComponent<InputManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        void Update()
        {
            if (_health.IsDied) return;

            inputManager.HandleAllInputs();

            if(!playerLocomotion.IsMoving && this.gameObject.tag == "Warrior") _fighter.WarriorAttack();
            if (!playerLocomotion.IsMoving && this.gameObject.tag == "Mage") _fighter.MageAttack();       
        }

        private void FixedUpdate()
        {
            if(!_fighter.IsAttacking) playerLocomotion.HandleAllMovement();
        }       
    }
}
