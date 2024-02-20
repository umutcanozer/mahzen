using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGDialogue;


namespace BGCore
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] Transform dungeonPoint;
        [SerializeField] Canvas screenBlack;

        [SerializeField] Material darkSkybox;
        [SerializeField] GameObject _light;
        [SerializeField] DialogueManager dialogueManager;

        private void OnTriggerEnter(Collider other)
        {
            if (!dialogueManager.isDialogueEnd) return;
            if(other.gameObject.tag == "Mage" || other.gameObject.tag == "Warrior")
            {
                StartCoroutine(ScreenTransition());
                other.transform.position = dungeonPoint.position;
            }
        }

        IEnumerator ScreenTransition()
        {
            screenBlack.enabled = true;
            RenderSettings.skybox = darkSkybox;
            _light.active = false;
            yield return new WaitForSeconds(2f);
            screenBlack.enabled = false;
        }
    }
}
