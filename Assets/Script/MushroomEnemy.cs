using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MushroomEnemy : MonoBehaviour
{
    bool isAction = false;
    public Transform postA;
    public Transform postB;
    private void Start()
    {
        Move();
    }
    private void Move()
    {
        this.transform.DOMoveX(postA.transform.position.x, 2).OnComplete(delegate
        {
            this.transform.DOMoveX(postB.transform.position.x, 2).OnComplete(delegate
            {
                Move();
            });
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Foot"))
        {
            if (!isAction)
            {
                isAction = true;
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isAction)
            {
                isAction = true;
                StateManager.instance.currentState.Hit(HitType.Enemy);
                Destroy(this.gameObject);
            }
        }
    }
}
