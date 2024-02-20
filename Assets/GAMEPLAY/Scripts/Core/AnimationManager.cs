using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BG.Core
{
    public class AnimationManager : MonoBehaviour
    {
        Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void UpdateMoveAnimation(float speed)
        {
            animator.SetFloat("speed", speed, 0.1f, Time.deltaTime);
        }

        public void UpdateAttackAnimations(int currentAttack)
        {
            animator.SetTrigger("Attack" + currentAttack);
        }

        public void UpdateSpellingAnimation(string attack)
        {
            animator.SetTrigger(attack);
        }

        public void ResetAttackTrigger(string attack)
        {
            animator.ResetTrigger(attack);
        }
    }
}
