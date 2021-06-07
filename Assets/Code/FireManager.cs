using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private TileBase ashTile, ashTilePile, ashTileTreeBase, ashTileTreeLeft, ashTileTreeRight, ashTileTreeMiddle;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Fire firePrefab;

    [SerializeField]
    private Fire firePrefabup;

   Fire newFire, newFire2;

    public GameObject allFires;

    [SerializeField]
    private FireNoCollider firePrefabNoCol;

    [SerializeField]
    private GameObject ashTilePileP, ashTileTreeBaseP, ashTileTreeLeftP, ashTileTreeRightP, ashTileTreeMiddleP,
        spruce1, spruce2, spruce3;
        

    // maybe we need to add fires to this list from other places as well
    public List<Vector3Int> activeFires = new List<Vector3Int>();
    //public List<Vector3Int> activeFiresNoCol = new List<Vector3Int>();

    public List<GameObject> Ashes = new List<GameObject>();
    public Transform player;

    Vector3Int playerPosition;
    Vector3Int radarRangeSize;
    Vector3 radarMaxRange = new Vector3(2f, 1f, 0);

    public BoundsInt area;
    public Transform block;

    public float burnRadius = 1.5f;

    public ScoreCounter scoreCounter;

    public BoundsInt bounds;
    public Vector2 pos;
    public Vector2 playerPosition2;
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }


    public void TryToSpread(Vector3Int position, float spreadChange) {
        for (int i = position.x -1; i < position.x + 2; i++) {
            for (int j = position.y - 1; j < position.y + 2; j++) {
                TryToBurnTile(new Vector3Int(i,j,0));
            }
        }

        void TryToBurnTile(Vector3Int tilePostion) {
            if (activeFires.Contains(tilePostion)) return;
            TileData data = mapManager.GetTileData(tilePostion);

            if(data != null && data.canBurn) {
                if (Random.Range(50f, 100f) <= data.spreadChange)
                    SetTileOnFire(tilePostion, data);
            }
        }
    }


    public void SetTileOnFire(Vector3Int tilePosition, TileData data) {

        Vector3Int tempTilepos = tilePosition;
        tempTilepos.y -= 1;
        TileData dataunder = mapManager.GetTileData(tempTilepos);
        //Fire newFire = Instantiate(firePrefab);
        //Fire newFire2 = Instantiate(firePrefabup);
        if (map.HasTile(tempTilepos) && dataunder.groudTile == true) {
            newFire = Instantiate(firePrefab);
            newFire.transform.SetParent(allFires.transform);
            newFire.transform.position = map.GetCellCenterWorld(tilePosition);
            newFire.StartBurning(tilePosition, data, this);
            activeFires.Add(tilePosition);
        } else  {
            newFire2 = Instantiate(firePrefabup);
            newFire2.transform.SetParent(allFires.transform);
            newFire2.transform.position = map.GetCellCenterWorld(tilePosition);
            newFire2.StartBurning(tilePosition, data, this);
            activeFires.Add(tilePosition);
        } 

        //activeFires.Add(tilePosition);
    }


    private void Update() {

        BurnFromPlayerPosition();

        //UpdateProximityArray();
        /*DifferentDirectionBurnX(-1);
        DifferentDirectionBurnX(1);
        DifferentDirectionBurnY(-1);
        DifferentDirectionBurnY(1);*/

        //var hitP = map.GetComponent<SparksBurnTiles>().hitPosition;
        //print(hitP);

    }

    void BurnFromPlayerPosition() {
         playerPosition2 = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition2);

        int gr = Mathf.FloorToInt(burnRadius + 0.5f);
        //var bounds = new BoundsInt(playergridPos, new Vector3Int(gr * 2 + 1, gr * 2 + 1, 1));
         bounds = new BoundsInt(playergridPos.x - gr, playergridPos.y - gr, 0, gr * 2 + 1, gr * 2 + 1, 1);
        
        var rsq = burnRadius * burnRadius;

        /*for (int x = bounds.position.x ; x < (bounds.position.x + bounds.size.x); x++) {
            for (int y = bounds.position.y ; y < (bounds.position.y + bounds.size.y); y++) {
                TileData data = mapManager.GetTileData(new Vector3Int(x, y, 0));
                var pos = (Vector2)map.CellToWorld(new Vector3Int(x, y, 0)) + Vector2.one * 0.5f;

                if (rsq >= (playerPosition - pos).sqrMagnitude) {
                    if (map.HasTile(new Vector3Int(x, y, 0)) && data.canBurn == true) {
                        if (activeFires.Contains(new Vector3Int(x, y, 0))) return;
                        SetTileOnFire(new Vector3Int(x, y, 0), data);
                    }
                }   
            }
        }*/

        foreach (var gpos in bounds.allPositionsWithin) {
             pos = (Vector2) map.CellToWorld(gpos) + Vector2.one*0.5f;
            TileData data = mapManager.GetTileData(gpos);
                if (rsq >= (playerPosition2 - pos).sqrMagnitude) {

                    Debug.DrawLine(playerPosition2, pos, Color.white);
                    if (map.HasTile(gpos) && data.canBurn == true) {
                        if (activeFires.Contains(gpos)) return; // ei sytytet‰ palavaa uudestaan
                        SetTileOnFire(gpos, data);
                    }
            } else Debug.DrawLine(playerPosition2, pos, Color.red);
        }
    }


    void DifferentDirectionBurnX(int added) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.x -= added;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.canBurn == true) {
            if (activeFires.Contains(playergridPos)) return; // ei sytytet‰ palavaa uudestaan
            SetTileOnFire(playergridPos, data);
        }
    }

    void DifferentDirectionBurnY(int added) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.y -= added;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.canBurn == true) {
            if (activeFires.Contains(playergridPos)) return; // ei sytytet‰ palavaa uudestaan
            SetTileOnFire(playergridPos, data);
        }
    }

    public void NewAshTile(Vector3Int tilePosition, GameObject pref) {

        GameObject ashT = Instantiate(pref);
        ashT.transform.position = map.GetCellCenterWorld(tilePosition);
        ashT.transform.SetParent(allFires.transform);
        //activeAshes.Add(tilePosition);
        //Ashes.Add(ashT);
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
                    if (activeFires.Contains(tilePositionInt)) return; // ei sytytet‰ palavaa uudestaan
                    SetTileOnFire(tilePositionInt, data);
                }
            }
        }
    }


    public void FinishedBurning(Vector3Int position) {
        TileData data = mapManager.GetTileData(position);

        map.SetTile(position, null);
        scoreCounter.scoreValue += 1;

        var strings = new List<string> { "TreeBase", "TreeLeft", "TreeRight", "BushesTiles", "TreeMiddle", 
        "Spruce1","Spruce2", "Spruce3"
        };

        var prefabs = new List<GameObject> { ashTileTreeBaseP, ashTileTreeLeftP, ashTileTreeRightP, ashTilePileP, ashTileTreeMiddleP,
         spruce1, spruce2, spruce3
        };

        if (!data.leavesTile) {
            //var idx = strings.IndexOf(data.name);
            //NewAshTile(position, prefabs[idx]);

            NewAshTile(position, data.burned);
        }
        activeFires.Remove(position);
    }


 

    // t‰‰ ainakin toimii :) mutta ei ehk‰ paras tapa
    public int GetTileAmountSprite() {
        int amount = 0;
        // loop through all of the tiles        
        BoundsInt bounds = map.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin) {
            TileData data = mapManager.GetTileData(pos);
            Tile tile = map.GetTile<Tile>(pos);
            if (tile != null) {
                if (data.canBurn == true && data.secret == false) {
                    amount += 1;
                }
            }
        }
        /*BoundsInt boundsNoCol = noCollidermap.cellBounds;
        foreach (Vector3Int pos in boundsNoCol.allPositionsWithin) {
            //TileData dataNoCol = mapManager.GetTileDataNoCollider(pos);
            Tile tileNoCol = noCollidermap.GetTile<Tile>(pos);
            if (tileNoCol != null) {
                if (dataNoCol.canBurn == true) {
                    amount += 1;
                }
            }
        }*/
        Debug.Log(amount);
        return amount;
    }

}
