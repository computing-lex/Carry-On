using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour { 

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private void Update()
    {
        if (!DialogueManager.GetInstance().dialogueisPlaying && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("bruh2");

            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }



}
