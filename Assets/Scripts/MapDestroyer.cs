using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile wallTile;
    [SerializeField] Tile destructibleTile;

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int explosionDistance = 3;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldPos);
        ExplodeCell(cellPos);

        if (ExplodeCell(cellPos + new Vector3Int(1, 0, 0)))
        {
            ExplodeCell(cellPos + new Vector3Int(2, 0, 0));
        }

        if (ExplodeCell(cellPos + new Vector3Int(-1, 0, 0)))
        {
            ExplodeCell(cellPos + new Vector3Int(-2, 0, 0));
        }

        if (ExplodeCell(cellPos + new Vector3Int(0, 1, 0)))
        {
            ExplodeCell(cellPos + new Vector3Int(0, 2, 0));
        }

        if (ExplodeCell(cellPos + new Vector3Int(0, -1, 0)))
        {
            ExplodeCell(cellPos + new Vector3Int(0, -2, 0));
        }

    }

    bool ExplodeCell(Vector3Int cell)
    {

        Tile tile = (Tile)tilemap.GetTile(cell);
     
        

        if(tile == wallTile)
        {
            return false;
        }
        else if(tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        var explosion = Instantiate(explosionPrefab, pos, Quaternion.identity);
        return true;
    }

}
