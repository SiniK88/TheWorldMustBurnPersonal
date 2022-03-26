using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilesOverlapPlayer : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Tilemap map;
    public FireManager fireManager;
    public Vector3 hitPosition;
    public Transform player;
    public List<Collider2D> tilesOverlapping = new List<Collider2D>();
    Vector3Int playerPosition;
    Vector3Int radarRangeSize;
    Vector3 radarMaxRange = new Vector3(0.9f,0.9f,0);
    void Start()
    {
        Vector3 playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateProximityArray() {
        // UPDATE PLAYER POSITION - USED TO DETERMINE THE STARTING POINT OF THE "ARRAY"
        playerPosition.x = (int)player.position.x;
        playerPosition.y = (int)player.position.y;

        // UPDATE RADAR MAX RANGE - USED TO DETERMINE THE SIZE OF THE "ARRAY"
        radarRangeSize.x = (int)radarMaxRange.x;
        radarRangeSize.y = (int)radarMaxRange.y;

        // CHECK FOR TILES AROUND THE PLAYER WITH A MAX DISTANCE BASED ON radarMaxRange
        for (int y = playerPosition.y - radarRangeSize.y; y < (playerPosition.y + radarRangeSize.y); y++) {
            for (int x = playerPosition.x - radarRangeSize.x; x < (playerPosition.x + radarRangeSize.x); x++) {
                Vector3 tilePosition = new Vector3(x, y, 0);
                Vector3Int tilePositionInt = new Vector3Int(Mathf.RoundToInt(tilePosition.x), Mathf.RoundToInt(tilePosition.y), 0);
                Tile tile = map.GetTile<Tile>(tilePositionInt);
                TileData data = mapManager.GetTileData(tilePositionInt);

                if (map.HasTile(tilePositionInt) && data.canBurn == true) {
                    if (fireManager.activeFires.Contains(tilePositionInt)) return; // ei sytytetä palavaa uudestaan
                    fireManager.SetTileOnFire(tilePositionInt, data);
                }
            }
        }
    }

}
