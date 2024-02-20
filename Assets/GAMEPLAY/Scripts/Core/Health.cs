using BGCombat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BGCore
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] float currentHealth;
        [SerializeField] bool isDied = false;
        Animator anim;
        AICombat combat;
        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = Mathf.Min(value, maxHealth);
        }

        public float MaxHealth
        {
            get => maxHealth;
        }

        void Start()
        {
            currentHealth = maxHealth;
            anim = GetComponent<Animator>();
            combat = GetComponent<AICombat>();
        }

        public bool IsDied { get { return isDied; } }

        public void TakeDamage(float damage)
        {
            
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            if(currentHealth == 0)
            {
                Die();
            }
        }

        void Die()
        {
            if (isDied) return;
            isDied = true;
            combat.Cancel();
            anim.SetTrigger("death");

            if(gameObject.tag == "Mage" || gameObject.tag == "Warrior")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}
