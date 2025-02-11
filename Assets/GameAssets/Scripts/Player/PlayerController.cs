using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _pos;
    private bool _canRun;

    [Header("lerp")]
    public Transform target;
    public float LerpSpeed = 1f;

    [Header("move")]
    public float speed = 1f;
    public string enemyTagCheck = "Enemy";
    public string endLineTagCheck = "EndLine";

    public GameObject endScreen;
    public GameObject startScreen;


    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (! _canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTagCheck)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == endLineTagCheck) 
        {
            EndGame();   
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }
}
