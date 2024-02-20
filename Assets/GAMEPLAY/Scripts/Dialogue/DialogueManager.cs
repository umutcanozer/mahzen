using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace BGDialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;

        Canvas _canvas;

        public TextMeshProUGUI characterName;
        public TextMeshProUGUI dialogueArea;

        Queue<DialogueLine> lines = new Queue<DialogueLine>();

        public bool isDialogueActive = false;
        public bool isDialogueEnd = false;
        public float typingSpeed = 0.2f;

        private void Start()
        {
            if (Instance == null) Instance = this;
            _canvas = GetComponent<Canvas>();
            _canvas.enabled = false;
        }
        private void Update()
        {
            Debug.Log(isDialogueActive);
        }
        public void StartDialogue(Dialogue dialogue)
        {
            isDialogueActive = true;
            _canvas.enabled = true;
            lines.Clear();

            foreach(DialogueLine dialogueLine in dialogue.dialogueLines)
            {
                lines.Enqueue(dialogueLine);
            }

            DisplayNextDialogueLine();
        }

        public void DisplayNextDialogueLine()
        {
            if(lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            DialogueLine currentLine = lines.Dequeue();

            characterName.text = currentLine.character.name;
            dialogueArea.text = currentLine.line;

        }

        
        void EndDialogue()
        {
            isDialogueActive = false;
            isDialogueEnd = true;
            _canvas.enabled = false;
        }
    }
}
