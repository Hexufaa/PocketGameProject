using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("item configs")]
    public string compareTag = "Player";
    public float timeToHide = 2f;
    public GameObject graphicItem;

    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }


    public void Collect()
    {
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);

    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}
