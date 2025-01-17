using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject itemPrefab;
    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private void Start()
    {
        InitSpawnPoints();
        Spanwenemy();
    }
    

    private void Spanwenemy()
    {
        foreach (var point in spawnPoints)
        {
            if (point.objIntance == null)
            {
                point.objIntance = Instantiate(itemPrefab, point.postition, Quaternion.identity);
            }
        }
    }

    private void InitSpawnPoints()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] alltile = tilemap.GetTilesBlock(bounds);
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(cellPos);
                if (tile != null)
                {
                    Vector3 worldPos = tilemap.CellToWorld(cellPos) + tilemap.tileAnchor;
                    spawnPoints.Add(new SpawnPoint(worldPos, null));
                }
            }
        }
    }
}


