using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CoinAnimatorManager : Singleton<CoinAnimatorManager>
{
    public List<CoinCollectableBase> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = 1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<CoinCollectableBase>();
    }

    public static new CoinAnimatorManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        StartAnimations();
        itens = new List<CoinCollectableBase>();
    }


    public void RegisterCoin(CoinCollectableBase i)
    {
        if (!itens.Contains(i))
        { 
            itens.Add(i); 
            i.transform.localScale = Vector3.zero;
            // todas as moedas aparecem em um unico lugar em cima da tag do piece
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))  {StartAnimations();}
            
    }

    public void StartAnimations()
    {
        StartCoroutine(ScaleCoinsByTime());
    }

    IEnumerator ScaleCoinsByTime()
    {
        foreach (var p in itens){ p.transform.localScale = Vector3.zero;}

        Sort();
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);

        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
    
