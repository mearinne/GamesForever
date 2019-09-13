using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour {

    public static int controlVal;

    Animator animator;
    private float counter;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private float startTime;
    private float endTime;
    private float finalTime;
    private void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpFallPose"))
        {
            StopCoroutine(deathWaiting());
            StartCoroutine(deathWaiting());
           
        }

       

    }

    public void buttonUP_wasPressed()
    {
        controlVal = 1;
    }
    public void buttonDOWN_wasPressed()
    {
        controlVal = -1;
    }

    public void buttonReleased()
    {
        controlVal = 0;
    }

    public void waitToDeath()
    {
        // animator.SetBool("isFallingTooLong", state);
        /* float L0MotionState = animator.GetFloat("L0MotionPhase");
         print(L0MotionState);
         animator.SetFloat("L0MotionPhase", 1840);
         animator.SetFloat("L0MotionParameter", 99);*/
       // animator.enabled = false;
       
    }

    private IEnumerator deathWaiting()
    {
         counter = 0.0f;
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpFallPose"))
        {
            counter+=0.05f;
            yield return null;
            print("counter "+counter);
            if (counter > 3f)
            {
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("MyController");
            }

        }

        
    }
}
