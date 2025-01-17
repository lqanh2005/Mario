using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject enemyPrefab;
    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private void Start()
    {
        InitSpawnPoints();
        Spanwenemy();
    }
    private void Update()
    {
        CheckAndRespawn();
    }

    private void CheckAndRespawn()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if(spawnPoint.objIntance == null)
            {
                StartCoroutine(RespawnEnemy(spawnPoint));
            }
        }
    }
    private IEnumerator RespawnEnemy(SpawnPoint spawnPoint)
    {
        yield return new WaitForSeconds(3f);
        if(spawnPoint.objIntance == null)
        {
            spawnPoint.objIntance = Instantiate(enemyPrefab, spawnPoint.postition, Quaternion.identity);
        }
    }

    private void Spanwenemy()
    {
        foreach (var point in spawnPoints)
        {
            if (point.objIntance == null)
            {
                point.objIntance = Instantiate(enemyPrefab, point.postition, Quaternion.identity);
            }
        }
    }

    private void InitSpawnPoints()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] alltile= tilemap.GetTilesBlock(bounds);
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(cellPos);
                if(tile != null)
                {
                    Vector3 worldPos= tilemap.CellToWorld(cellPos)+ tilemap.tileAnchor;
                    spawnPoints.Add(new SpawnPoint(worldPos, null));
                }
            }
        }
    }
}
public class SpawnPoint
{
    public Vector3 postition;
    public GameObject objIntance;
    public SpawnPoint(Vector3 pos, GameObject obj)
    {
        this.postition = pos;
        this.objIntance = obj;
    }
}
