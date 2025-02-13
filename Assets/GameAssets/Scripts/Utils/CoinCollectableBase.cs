using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectableBase : ItemCollectableBase
{
    public Collider collider;
    public bool collect = false;
    public float minDistance = 1f;
    public float lerp = 5f;

    private void Start()
    {
        //CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    protected override void Collect()
    {
        base.Collect();
        collider.enabled = false;
        collect = true;
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, 
                PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if(Vector3.Distance(transform.position, 
                PlayerController.Instance.transform.position) < minDistance)
            {
                Destroy(gameObject);
            }
        }
    }

}
