using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;

    [Header("lerp")]
    public Transform target;
    public float LerpSpeed = 1f;

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    [Header("move")]
    public float speed = 1f;
    public string enemyTagCheck = "Enemy";
    public string endLineTagCheck = "EndLine";

    public GameObject endScreen;
    public GameObject startScreen;

    [Header("Power Ups")]
    public bool invencible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;


    public void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }


    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }

    void Update()
    {
        if (! _canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTagCheck)
        {
            if(!invencible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == endLineTagCheck)
        {
            if(!invencible) EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    #region POWER UPS

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration)
    {
        var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;
    }

    public void ResetHeight()
    {
        var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;
    }



    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion


    //Instances

    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }
}
