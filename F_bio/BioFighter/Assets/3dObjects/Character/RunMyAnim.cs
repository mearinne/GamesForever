using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMyAnim : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(runAnim());
        }
      
     
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("NewAnim", 0);
        }

    }

    private IEnumerator runAnim()
    {
        while (Input.GetKeyDown(KeyCode.S))
        {
            yield return null;
            anim.SetInteger("NewAnim", 1);

        }
    }
}
