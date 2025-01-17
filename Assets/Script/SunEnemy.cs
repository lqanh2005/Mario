using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunEnemy : MonoBehaviour
{
    public Animator animator;
    public GameObject playerPos;
    [Header("Movement Setting")]
    public Transform targetPos;
    public float speed = 2f;
    [Header("Bullet Setting")]
    public GameObject bulletPrefab;
    public float spawnRate = 2f;
    public float bulletSpeed = 4f;

    public bool isReachtarger=false; // di chuyển đến vị trí đã định chưa
    private void Update()
    {
        if (!isReachtarger)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos.position, speed*Time.deltaTime);
        if(Vector2.Distance(this.transform.position, targetPos.position) < 0.1f)
        {
            isReachtarger = true;
            StartCoroutine(SpawnBullet());
        }
    }

    private IEnumerator SpawnBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            animator.Play("Attack");
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            Vector2 direction = (playerPos.transform.position - this.transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
