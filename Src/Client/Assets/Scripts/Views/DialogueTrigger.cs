using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Managers;

namespace MyGame
{
    [System.Serializable]
    public class DialogueEvent : UnityEvent<string[]> { };
    public class DialogueTrigger : MonoBehaviour
    {
        public int index;
        public DialogueEvent dialogueEvent;

        public void Trigger()
        {
            dialogueEvent.Invoke(DialogueManager.Instance.GetDialogue(index));
        }
    }
}
