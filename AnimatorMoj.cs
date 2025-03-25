using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMoj : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            anim.Play("jump_up");
        }
        if(Input.GetKeyDown(KeyCode.X)){
            anim.Play("idle_fight");
        }

    }
    
}
