using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ChangeTileColor : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Tilemap map;
    
    private Tilemap burnedMap;
    //public Tile burned;
    public RuleTile burned;

    public GameObject player;
    void Start()
    {
        burnedMap = GetComponent<Tilemap>();

    }

    void Update()
    {
        ChangeStandingTileColor(Color.red, 1);
    }

    void ChangeStandingTileColor(Color color,int added) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.y -= added;

        TileData data = mapManager.GetTileData(playergridPos);
        color = new Color(0.6f, 0.9f, 0.9f, 1);
        if (map.HasTile(playergridPos) && data.groudTile == true) {
            burnedMap.SetTile(playergridPos, burned);
            //map.SetTileFlags(playergridPos, TileFlags.None);

            //map.SetColor(playergridPos, color);
        }
    }
}
