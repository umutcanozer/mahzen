using BGCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGCombat
{
    public class Magic : MonoBehaviour
    {
        float damage = 50f;
        float duration = 3f;
        GameObject player;        
        Health health;
        Fighter fighter;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                health = other.gameObject.GetComponent<Health>();
                health.TakeDamage(damage);                
            }
            Destroy(gameObject);
        }

        private void Update()
        {
            Invoke("DestroyItself", duration);
        }

        void DestroyItself()
        {
            Destroy(gameObject);
        }


    }
}
