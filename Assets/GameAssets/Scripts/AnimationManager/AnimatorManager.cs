using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class animatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD,
    }
    
    public void Play(AnimationType type)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.IDLE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.RUN);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.DEAD);
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public animatorManager.AnimationType type;
        public string trigger;
    }

}
