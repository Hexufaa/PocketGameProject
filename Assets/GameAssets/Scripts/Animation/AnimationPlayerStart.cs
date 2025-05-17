using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationPlayerStart : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = 1.5f;
    public float delayEnd = 5f;
    public Ease ease = Ease.Linear;

    public float shrinkDuration = 0.5f;
    public Vector3 shrinkScale = new Vector3(0.01f, 0.01f, 0.01f);
    public Ease shrinkEase = Ease.InBack;

    public float powerUpScale = 1.2f;
    public float PowerUpscaleDuration = 1.0f;
    public Vector3 PowerUpVector = new Vector3(1.0f, 1.0f, 1.0f);
    public Ease powerUpEase = Ease.OutBack;

    
    public void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, scaleDuration).SetEase(ease);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            transform.DOScale(shrinkScale, shrinkDuration).SetDelay(delayEnd).SetEase(shrinkEase);
        }
        if(other.CompareTag("powerUp"))
        {
            transform.DOScale(PowerUpVector, PowerUpscaleDuration).SetEase(powerUpEase).SetLoops(2, LoopType.Yoyo);
        }
    }

    
    

}
