using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChange : MonoBehaviour
{
    public float switchInterval = 5.0f;
    private Animator animator;
    private float timer;

    private void Start()
    {
        {
            animator = GetComponent <Animator>();
            timer = switchInterval;
        }
    }
    private void Update()
    {
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SwitchAnimation();
                timer = switchInterval;

            }
              
        }
    }
    private void SwitchAnimation()
            {
                animator.SetTrigger("Stopp");
            }
}

    
        
    

