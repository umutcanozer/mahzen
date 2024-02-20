using BGCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGCombat
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] float damage;
        
        Health health;
        MeshCollider meshCollider;

        bool hasHit = false;

        public bool HasHit
        {
            set => hasHit = value; 
        }
        public float Damage 
        { 
            set => damage = value; 
        }
        private void OnTriggerEnter(Collider other)
        {
            if(meshCollider != null) meshCollider = GetComponent<MeshCollider>();
            var enemyHealth = other.gameObject.GetComponent<Health>();
            if (other.gameObject.tag == "Enemy" && !hasHit)
            {
                hasHit = true;
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
