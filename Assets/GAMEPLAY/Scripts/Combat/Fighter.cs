using BG.Core;
using BGCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace BGCombat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] Sword sword;
        Health health;
        [SerializeField] float timeSinceLastAttack;
        float timeBeetweenAttacks = 0.8f;
        [SerializeField] int currentAttack;
        int attackComboNo = 3;
        [SerializeField] float rotationSpeed = 50.0f;
        bool isAttacking = false;
        bool isClicked = false;

        AnimationManager animationManager;
        Camera _camera;
        CombatTarget target;

        public bool IsAttacking { get => isAttacking; }

        public CombatTarget Target
        {
            get => target;
            set => target = value;
        }
        void Start()
        {                      
            animationManager = GetComponent<AnimationManager>();
            health = GetComponent<Health>();
            _camera = Camera.main;
        }


        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        
        public void WarriorAttack()
        {
            RotateTowardsTarget();           
            if (Input.GetMouseButtonDown(0) && InteractWithCombat())
            {                
                isClicked = true;
                if (timeSinceLastAttack > timeBeetweenAttacks)
                {
                    currentAttack++;
                    isAttacking = true;
                    DamageCalculation();
                    if (timeSinceLastAttack > 3f) { currentAttack = 1; }
                    if (currentAttack > attackComboNo) { currentAttack = 1; }

                    animationManager.UpdateAttackAnimations(currentAttack);

                    timeSinceLastAttack = 0;
                }                
            }
        }


        public void MageAttack()
        {
            RotateTowardsTarget();
            if (Input.GetMouseButtonDown(0) && InteractWithCombat())
            {
                isClicked = true;
                if (timeSinceLastAttack > timeBeetweenAttacks)
                {                   
                    isAttacking = true;
                    animationManager.UpdateSpellingAnimation("Attack");

                    timeSinceLastAttack = 0;
                }
            }
        }

        void RotateTowardsTarget()
        {
            if (target == null || !isClicked) return;
            Vector3 direction = (target.transform.position - transform.position);
            direction = Vector3.ClampMagnitude(direction, 1);
            direction.y = 0f;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = playerRotation;
        }

        public void ResetAttack()
        {
            isAttacking = false;
            isClicked = false;
            if(sword != null) sword.HasHit = false;
            animationManager.ResetAttackTrigger("Attack");
        }

        public bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                return true;
            }
            return false;
        }

        private Ray GetMouseRay()
        {
            return _camera.ScreenPointToRay(Input.mousePosition);
        }

        void DamageCalculation()
        {
            switch (currentAttack)
            {
                case 1:
                    sword.Damage = 10f;
                    break;
                case 2:
                    sword.Damage = 15f;
                    break;
                case 3:
                    sword.Damage = 25f;
                    health.CurrentHealth = health.CurrentHealth + 25;
                    break;
                default:
                    sword.Damage = 10f;
                    break;
            }
        }
    }
}
