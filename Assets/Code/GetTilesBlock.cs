using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GetTilesBlock : MonoBehaviour
{
    public BoundsInt area;
    public Tilemap tilemap;
    public TileBase[] tileArray;
    public BoundsInt bounds;
    public Transform block;
    public TileBase[] allTiles;
    public List<Vector3> tileWorldLocations;
    SpriteRenderer spriteblock;

    public GameObject player;
    public RayCastPlayer playercontroller;


    public List<GameObject> collidingList = new List<GameObject>();
    void Start() {
        playercontroller = player.GetComponent<RayCastPlayer>();
        tileWorldLocations = new List<Vector3>();
        Tilemap tilemap = GetComponent<Tilemap>();
        var spriteblock = block.GetComponent<SpriteRenderer>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin) {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (tilemap.HasTile(localPlace)) {
                tileWorldLocations.Add(place);
            }
        }

        BoundsInt bounds = tilemap.cellBounds; // koko mappi
        allTiles = tilemap.GetTilesBlock(bounds);
        //area = new BoundsInt(new Vector3Int(Mathf.RoundToInt(block.position.x), Mathf.RoundToInt(block.position.y), 0), size: new Vector3Int(Mathf.RoundToInt(block.localScale.x), Mathf.RoundToInt(block.localScale.y), 0)) ;
        area = new BoundsInt(new Vector3Int((int)(block.position.x), (int)(block.position.y), 0), size: new Vector3Int((int)(block.localScale.x), (int)(block.localScale.y), 0)) ;
        tileArray = tilemap.GetTilesBlock(area);

        // huomioi miten for looppi toimii.Pit‰isi olla mahdollista saada tuo toimimaan, mutta jos area size ja alku positio samat, ei tietenk‰‰n looppaa siit‰ mit‰‰n eteenp‰in.
        var origin = tilemap.origin;
        for (int x = area.position.x-1; x < (area.position.x + area.size.x) ; x++) {
            for (int y = area.position.y -1 ; y < (area.position.y + area.size.y); y++) {
                //TileBase tile = allTiles[x + y * bounds.size.x];
                if (allTiles != null) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
        allTiles = tilemap.GetTilesBlock(bounds);

        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (playercontroller.dash == true) {
            if (!collidingList.Contains(collision.gameObject))
                collidingList.Add(collision.gameObject);


        }
    }

    private void Update() {
        var dashbool = playercontroller.dash;
        print(dashbool);
        
        if(playercontroller.dash == true) {
            
            

        }



    }



}
