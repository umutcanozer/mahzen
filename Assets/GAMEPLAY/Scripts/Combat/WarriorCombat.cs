using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BGCombat
{
    public class WarriorCombat : MonoBehaviour
    {
        [SerializeField] GameObject meshCollider;

        public void Hit()
        {
            StartCoroutine(ColliderState());
        }

        IEnumerator ColliderState()
        {
            meshCollider.GetComponent<MeshCollider>().enabled = true;
            yield return new WaitForSeconds(0.75f);
            meshCollider.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
