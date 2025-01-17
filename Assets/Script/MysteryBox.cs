using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public GameObject spawnPrefab;
    [Range(0f,1f)] public float spawnChance;
}
public class MysteryBox : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Hit");
            foreach(var item in itemList)
            {
                if(item.spawnPrefab != null)
                {
                    float randomValue = Random.Range(0f, 1f);
                    if(randomValue <= item.spawnChance)
                    {
                        Instantiate(item.spawnPrefab, transform.position, Quaternion.identity);
                        break;
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
