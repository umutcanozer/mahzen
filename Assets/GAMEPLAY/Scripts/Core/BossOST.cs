using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGCore
{
    public class BossOST : MonoBehaviour
    {
        AudioSource source;
        BoxCollider boxCollider;

        [SerializeField] Canvas bossHealthBar;
        private void Start()
        {
            bossHealthBar.enabled = false;
            source = GetComponent<AudioSource>();
            boxCollider = GetComponent<BoxCollider>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Mage" || other.gameObject.tag == "Warrior")
            {
                
                source.Play();
                bossHealthBar.enabled = true;
                boxCollider.enabled = false;
            }
        }
    }
}
