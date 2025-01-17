using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float lifetime = 5f;
    private void Start()
    {
        Destroy(gameObject,lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
