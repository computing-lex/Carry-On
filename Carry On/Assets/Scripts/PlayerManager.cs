using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator myAnimator;
    [SerializeField] private GameObject root;
    [SerializeField] private float speed;
    [SerializeField] private string trigger;
    [SerializeField] private int distanceToNextTrash;
    [SerializeField] public GameObject Trigger1;

    public int days;
    public bool eventActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {

            myAnimator.SetBool(trigger, false);
            root.transform.position = new Vector3(root.transform.position.x + (speed * Time.deltaTime), root.transform.position.y, root.transform.position.z);

        }
        else
        {
            myAnimator.SetBool(trigger, true);
        }


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Trigger1.transform.position = new Vector3(Trigger1.transform.position.x + distanceToNextTrash, 0, 0);
        eventActive = true;
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        eventActive = false;

    }


}
