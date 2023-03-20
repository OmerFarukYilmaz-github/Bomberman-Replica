using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile wallTile;
    [SerializeField] Tile destructibleTile;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldPos);
        ExplodeCell(cellPos);
    }

    void ExplodeCell(Vector3Int cell)
    {
        Tile tile = (Tile)tilemap.GetTile(cell);
     
        if(tile == wallTile)
        {
            return;
        }
        else if(tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
        }
    }

}
