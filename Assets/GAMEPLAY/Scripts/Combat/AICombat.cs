using BGCore;
using BGMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGCombat
{
    public class AICombat : MonoBehaviour
    {
        [SerializeField] float range = 2f;

        [SerializeField] float timeBetweenAttacks = 15f;

        [SerializeField] float attackDamage = 5f;

        Health target;
        AIMovement movement;

        float timeSinceLastAttack = 0f;

        Animator anim;
        public Health Target
        {
            get => target;
        }
        
        private void Start()
        {
            anim = GetComponent<Animator>();
            movement = GetComponent<AIMovement>();
        }

        private void Update()
        {
            Debug.Log(timeSinceLastAttack);
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDied) return;

            if (!GetInRange())
            {
                movement.MoveTo(target.transform.position);
            }
            else
            {
                movement.Cancel();
                AttackBehaviour();
            }
        }

        public void Hit()
        {
            if (target == null) return;
            target.TakeDamage(attackDamage);
        }

        void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0f;
            }           
        }

        void TriggerAttack()
        {
            anim.ResetTrigger("stopAttack");
            anim.SetTrigger("attack");
        }
        public void Attack(GameObject combatTarget)
        {
            target = combatTarget.GetComponent<Health>();
        }

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < range;
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;

            Health targetTest = combatTarget.GetComponent<Health>();
            return targetTest != null && !targetTest.IsDied;
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        public void StopAttack()
        {
            anim.ResetTrigger("attack");
            anim.SetTrigger("stopAttack");
        }
    }
}
