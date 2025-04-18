using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{

    public Animation animation;

    public AnimationClip run;
    public AnimationClip idle;

    void Start()
    {
        
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.A))        {PlayAnimation(run);}
        else if (Input.GetKeyDown(KeyCode.S))   {PlayAnimation(idle);}
    }
        private void PlayAnimation(AnimationClip c)
    {
        animation.CrossFade(c.name);
    }

    
}
