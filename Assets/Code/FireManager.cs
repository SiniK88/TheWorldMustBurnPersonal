using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    public Tilemap mapMoving;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Fire firePrefab;


    [SerializeField]
    private FireMoving firePrefab2;


    Fire newFire;
    FireMoving newFire3;

    public GameObject allFires;


    public Transform player;
    public Transform burnedParticle;

    public List<Vector3Int> activeFires = new List<Vector3Int>();

    public BoundsInt area;

    public float burnRadius = 1.5f;

    public ScoreCounter scoreCounter;

    public BoundsInt bounds;
    public Vector2 pos;
    public Vector2 playerPosition2;
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        mapMoving = GameObject.FindGameObjectWithTag("MovingMap").GetComponent<Tilemap>();

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

    public void TryToSpreadMoving(Vector3Int position, float spreadChange) {
        for (int i = position.x - 1; i < position.x + 2; i++) {
            for (int j = position.y - 1; j < position.y + 2; j++) {
                TryToBurnTile(new Vector3Int(i, j, 0));
            }
        }

        void TryToBurnTile(Vector3Int tilePostion) {
            if (activeFires.Contains(tilePostion)) return;
            TileData data = mapManager.GetTileDataMoving(tilePostion);

            if (data != null && data.canBurn) {
                if (Random.Range(50f, 100f) <= data.spreadChange)
                    SetTileOnFireMoving(tilePostion, data);
            }
        }
    }

    public void SetTileOnFire(Vector3Int tilePosition, TileData data) {

        Vector3Int tempTilepos = tilePosition;
        tempTilepos.y -= 1;
        //TileData dataunder = mapManager.GetTileData(tempTilepos);
        //Fire newFire = Instantiate(firePrefab);
        //Fire newFire2 = Instantiate(firePrefabup);
        newFire = Instantiate(firePrefab);
        newFire.transform.SetParent(allFires.transform);
        newFire.transform.position = map.GetCellCenterWorld(tilePosition);
        newFire.StartBurning(tilePosition, data, this);
        activeFires.Add(tilePosition);

        /*if (map.HasTile(tempTilepos) && dataunder.groudTile == true) {
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
        } */ // this pne had different fire animation for firest touching the ground
        //activeFires.Add(tilePosition);
    }

    public void SetTileOnFireMoving(Vector3Int tilePosition, TileData data) {

        Vector3Int tempTilepos = tilePosition;
        tempTilepos.y -= 1;
        //TileData dataunder = mapManager.GetTileDataMoving(tempTilepos);

        newFire3 = Instantiate(firePrefab2);
        newFire3.transform.SetParent(allFires.transform);
        newFire3.transform.position = mapMoving.GetCellCenterWorld(tilePosition);
        newFire3.StartBurning(tilePosition, data, this);
        activeFires.Add(tilePosition);


        /*if (mapMoving.HasTile(tempTilepos) && dataunder.groudTile == true) {
            newFire3 = Instantiate(firePrefab2);
            newFire3.transform.SetParent(allFires.transform);
            newFire3.transform.position = mapMoving.GetCellCenterWorld(tilePosition);
            newFire3.StartBurning(tilePosition, data, this);
            activeFires.Add(tilePosition);
        } else {
            newFire4 = Instantiate(firePrefabup2);
            newFire4.transform.SetParent(allFires.transform);
            newFire4.transform.position = mapMoving.GetCellCenterWorld(tilePosition);
            newFire4.StartBurning(tilePosition, data, this);
            activeFires.Add(tilePosition);
        }*/
        //activeFires.Add(tilePosition);
    }


    private void Update() {

        BurnFromPlayerPosition();
        BurnFromPlayerPositionMoving();
        //var hitP = map.GetComponent<SparksBurnTiles>().hitPosition;


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
                        if (activeFires.Contains(gpos)) return; // ei sytytet� palavaa uudestaan
                        SetTileOnFire(gpos, data);
                    }
            } else Debug.DrawLine(playerPosition2, pos, Color.red);
        }
    }

    void BurnFromPlayerPositionMoving() {
        playerPosition2 = player.transform.position;
        Vector3Int playergridPos = mapMoving.WorldToCell(playerPosition2);

        int gr = Mathf.FloorToInt(burnRadius + 0.5f);
        //var bounds = new BoundsInt(playergridPos, new Vector3Int(gr * 2 + 1, gr * 2 + 1, 1));
        bounds = new BoundsInt(playergridPos.x - gr, playergridPos.y - gr, 0, gr * 2 + 1, gr * 2 + 1, 1);

        var rsq = burnRadius * burnRadius;

        foreach (var gpos in bounds.allPositionsWithin) {
            pos = (Vector2)mapMoving.CellToWorld(gpos) + Vector2.one * 0.5f;
            TileData data = mapManager.GetTileDataMoving(gpos);
            if (rsq >= (playerPosition2 - pos).sqrMagnitude) {

                Debug.DrawLine(playerPosition2, pos, Color.white);
                if (mapMoving.HasTile(gpos) && data.canBurn == true) {
                    if (activeFires.Contains(gpos)) return; // ei sytytet� palavaa uudestaan
                    SetTileOnFireMoving(gpos, data);
                }
            } else Debug.DrawLine(playerPosition2, pos, Color.red);
        }
    }

    public void NewAshTile(Vector3Int tilePosition, GameObject pref) {

        GameObject ashT = Instantiate(pref);
        ashT.transform.position = map.GetCellCenterWorld(tilePosition);
        ashT.transform.SetParent(allFires.transform);

    }




    public void FinishedBurning(Vector3Int position) {
        TileData data = mapManager.GetTileData(position);

        BurnedParticles(position);

        map.SetTile(position, null);
        if (scoreCounter) {
            scoreCounter.scoreValue += 1;
        }

        if (!data.leavesTile) {
            //var idx = strings.IndexOf(data.name);
            //NewAshTile(position, prefabs[idx]);
            NewAshTile(position, data.burned);
        }
        activeFires.Remove(position);
    }

    public void FinishedBurningMoving(Vector3Int position) {
        TileData data = mapManager.GetTileDataMoving(position);

        BurnedParticles(position);
        mapMoving.SetTile(position, null);
        if (scoreCounter) {
            scoreCounter.scoreValue += 1;
        }

        if (!data.leavesTile) {
            NewAshTile(position, data.burned);
        }
        activeFires.Remove(position);
    }


    void BurnedParticles( Vector3 posit ) {
        var EndParticleclone = Instantiate(burnedParticle,posit , transform.rotation);
        Destroy(EndParticleclone.gameObject, 1.5f);

    }

    // t�� ainakin toimii :) mutta ei ehk� paras tapa
    public int GetTileAmountSprite() {
        int amount = 0;
        // loop through all of the tiles        
        BoundsInt bounds = map.cellBounds;
        BoundsInt bounds2 = mapMoving.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin) {
            TileData data = mapManager.GetTileData(pos);
            TileData data2 = mapManager.GetTileDataMoving(pos);
            Tile tile = map.GetTile<Tile>(pos);
            if (tile != null) {
                if (data.canBurn == true && data.secret == false) {
                    amount += 1;
                }
            }
        }

        foreach (Vector3Int pos in bounds2.allPositionsWithin) {
            TileData data2 = mapManager.GetTileDataMoving(pos);
            Tile tile = mapMoving.GetTile<Tile>(pos);
            if (tile != null) {
                if (data2.canBurn == true && data2.secret == false) {
                    amount += 1;
                }
            }
        }

        Debug.Log(amount);
        return amount;
    }

}
