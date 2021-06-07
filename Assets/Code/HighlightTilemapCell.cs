using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

public class HighlightTilemapCell : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;

    private Vector3Int previous;

    [SerializeField]
    private MapManager mapManager;

    private void LateUpdate() {
        // current grid location
        Vector3Int currentCell = highlightMap.WorldToCell(transform.position);

        currentCell.x += 1;

        //jos paikka on muuttunut
        if(currentCell != previous) {
            highlightMap.SetTile(currentCell, highlightTile);

            // erase previous highlight
            highlightMap.SetTile(previous, null);

            previous = currentCell;
        }
    }


}
