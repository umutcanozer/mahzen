using BGMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGDialogue
{
    [System.Serializable]
    public class DialogueCharacter
    {
        public string name;
    }

    [System.Serializable]
    public class DialogueLine
    {
        public DialogueCharacter character;
        [TextArea(3, 10)]
        public string line;
    }

    [System.Serializable]
    public class Dialogue
    {
        public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    }

    public class DialgueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        SphereCollider sphereCollider;
        public void TriggerDialogue()
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }

        private void Start()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }
        private void Update()
        {
            if(DialogueManager.Instance.isDialogueEnd) sphereCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if((other.gameObject.tag == "Warrior" || other.gameObject.tag == "Mage") && !DialogueManager.Instance.isDialogueActive)
            {
                TriggerDialogue();
            }
        }
    }
}
