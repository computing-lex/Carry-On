using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour { 

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private void Update()
    {
        if (!(DialogueManager.GetInstance().dialogueisPlaying))
        {
            Debug.Log("bruh2");
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }



}
