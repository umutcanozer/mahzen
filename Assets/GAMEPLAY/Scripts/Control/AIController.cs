using BGCombat;
using BGCore;
using BGMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGControl
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject player;
        GameObject mage;
        GameObject warrior;

        AIMovement movement;
        AICombat combat;
        Health health;

        private void Start()
        {
            warrior = GameObject.FindWithTag("Warrior");
            mage = GameObject.FindWithTag("Mage");
            if(mage != null)
            {
                player = mage;
            }else if(warrior != null)
            {
                player = warrior;
            }


            movement = GetComponent<AIMovement>();
            combat = GetComponent<AICombat>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDied) return;

            if(InRange() && combat.CanAttack(player))
            {
                   
                AttackBehaviour();
            }
            else
            {
                combat.Cancel();
            }
        }

        void AttackBehaviour()
        {
            combat.Attack(player);
        }

        bool InRange()
        {
            float v = Vector3.Distance(player.transform.position, transform.position);
            return v < chaseDistance;
        }
    }
}
