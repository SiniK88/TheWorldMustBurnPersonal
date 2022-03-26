using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private Tilemap mapMoving;

    [SerializeField]
    List<TileData> tileDatas;

    public Dictionary<TileBase, TileData> dataFromTiles;
    public Dictionary<TileBase, TileData> dataFromTilesMoving;
    public Dictionary<TileBase, TileData> dataFromTilesAll;
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        mapMoving = GameObject.FindGameObjectWithTag("MovingMap").GetComponent<Tilemap>();
    }

    void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        dataFromTilesMoving = new Dictionary<TileBase, TileData>();
        dataFromTilesAll = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas) {
            foreach (var tile in tileData.tiles) {
                dataFromTiles.Add(tile, tileData);
            }
        }

        foreach (var tileData in tileDatas) {
            foreach (var tile in tileData.tiles) {
                dataFromTilesMoving.Add(tile, tileData);
            }
        }


    }

    public TileData GetTileDataAll(Vector3Int tilePosition) {
        TileBase tile = map.GetTile(tilePosition);
        TileBase tile2 = mapMoving.GetTile(tilePosition);
        if (tile == null && tile2 == null)
            return null;
        else {
            if (tile2 == null) {
                return dataFromTilesAll[tile];
            } else return dataFromTilesAll[tile2];
        }
    }

    public TileData GetTileData(Vector3Int tilePosition) {
        TileBase tile = map.GetTile(tilePosition);
        if (tile == null)
            return null;
        else
            return dataFromTiles[tile];
    }

    public TileData GetTileDataMoving(Vector3Int tilePosition) {
        TileBase tile = mapMoving.GetTile(tilePosition);
        if (tile == null)
            return null;
        else
            return dataFromTilesMoving[tile];
    }

    private void Update() {
        /* if (Input.GetMouseButtonDown(0)) {
             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Vector3Int gridPosition = map.WorldToCell(mousePosition);

             TileBase clickedTile = map.GetTile(gridPosition);

         }*/

        // get tile where player is standing
        //Vector2 playerPos = player.transform.position;
        //Vector3Int playergridPosition = map.WorldToCell(playerPos);
        //playergridPosition.y -= 1;
 
    }


}
