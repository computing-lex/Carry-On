using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Animator Controls
    [Header("Animation Controls")]
    public Animator myAnimator;
    [SerializeField] private string animationTrigger;

    // Player movement
    [Header("Player Movement")]
    [SerializeField] private GameObject root;
    [SerializeField] private float speed;

    // Event handling
    [SerializeField] private int eventDistance;
    [SerializeField] public GameObject eventTrigger;

    // Player stats
    [Header("Player Attributes")]
    public int days;
    public int health;
    public int maxHealth;
    public int battery;

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

            myAnimator.SetBool(animationTrigger, false);
            root.transform.position = new Vector3(root.transform.position.x + (speed * Time.deltaTime), root.transform.position.y, root.transform.position.z);

        }
        else
        {
            myAnimator.SetBool(animationTrigger, true);
        }


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        eventTrigger.transform.position = new Vector3(eventTrigger.transform.position.x + eventDistance, 0, 0);
        eventActive = true;
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        eventActive = false;

    }


}
