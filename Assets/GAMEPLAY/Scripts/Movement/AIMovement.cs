using BGCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BGMovement
{
    public class AIMovement : MonoBehaviour
    {
        NavMeshAgent nma;
        Animator anim;

        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
            nma = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            nma.enabled = !health.IsDied;
            UpdateAnimator();
        }
        public void MoveTo(Vector3 _destination)
        {
            nma.destination = _destination;
            nma.isStopped = false;
        }

        public void Cancel()
        {
            nma.isStopped = true;
        }

        void UpdateAnimator()
        {
            Vector3 velo = nma.velocity;
            Vector3 localVelo = transform.InverseTransformDirection(velo);

            float speed = localVelo.z;
            anim.SetFloat("forwardSpeed", speed);
        }
    }
}
