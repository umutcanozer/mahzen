using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BGCombat
{
    public class MageCombat : MonoBehaviour
    {
        [SerializeField] GameObject spellPrefab;
        [SerializeField] Transform spawnPoint;
        
        float spellVel = 5f;

        Fighter fighter;
        
        private void Start()
        {
            fighter = GetComponent<Fighter>();
        }

        public void Hit()
        {            
            var spell = Instantiate(spellPrefab, spawnPoint.position, spawnPoint.rotation);
            var rb = spell.AddComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.useGravity = false;

            Vector3 crosshair = new Vector3(fighter.Target.transform.position.x, fighter.Target.transform.position.y, fighter.Target.transform.position.z);
            Vector3 fireDirection = (crosshair - spawnPoint.position).normalized;
            rb.AddForce(fireDirection * spellVel, ForceMode.Impulse);
        }       
    }
}
