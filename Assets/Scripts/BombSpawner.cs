using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject bombPrefab;
 

    // Update is called once per frame
    void Update()
    {
        // Tiklanan tilein,gridin merkezini alma
        if(Input.GetMouseButtonDown(0))
        {
           Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Vector3Int cellPos = tilemap.WorldToCell(worldPos);
           Vector3 cellCenterPos =  tilemap.GetCellCenterWorld(cellPos);
           Instantiate(bombPrefab,cellCenterPos, Quaternion.identity);
        }
    }
}
